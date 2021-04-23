using BSC.Database;
using BSC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static BSC.Models.TokenSnifferJsonModel;

namespace BSC {
    internal class Program {
        
        const string BscScanApiKey = "CXAIQDU54JAGTW65VMWI2AK8TYHQY722W5";
        private static IServiceProvider _serviceProvider;

        static async Task Main(string[] args) {
            RegisterServices();

            Migrate();

            bool stop = false;
            do {
                var scope = _serviceProvider.CreateScope();
                var pService = scope.ServiceProvider.GetRequiredService<IPancakseSwap>();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                var result = await pService.GetTokensAsync();

                if(!await dbContext.Tokens.AnyAsync(x => x.UpdatedAt == result.UpdatedAt).ConfigureAwait(false)) {
                    Console.WriteLine(result.UpdatedAt);

                    foreach(var token in result.Tokens) {
                        var entity = new Database.Models.Token {
                            Id = token.Key,
                            UpdatedAt = result.UpdatedAt,
                            Name = token.Value.Name,
                            Price = token.Value.Price,
                            Price_BNB = token.Value.Price,
                            Symbol = token.Value.Symbol
                        };

                        await dbContext.Tokens
                            .AddAsync(entity)
                            .ConfigureAwait(false);
                    }

                    await dbContext
                        .SaveChangesAsync()
                        .ConfigureAwait(false);
                } else {
                    Console.WriteLine("No new data");
                }

                await Task.Delay(TimeSpan.FromMinutes(1)).ConfigureAwait(false);
            } while (stop == false);
        }

        private static void Migrate() {
            var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            dbContext.Database.Migrate();
        }

        private static void RegisterServices() {
            var services = new ServiceCollection();
            services.AddSingleton<IPancakseSwap, PancakeSwap>();
            services.AddSingleton<ITokenSniffer, TokenSniffer>();
            services.AddSingleton<ITokenfomo, Tokenfomo>();
            services.AddDbContext<Database.ApplicationContext>();

            services.AddHttpClient();
            
            _serviceProvider = services.BuildServiceProvider(true);
        }
    }
}
