using BSC.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            var fomoService = _serviceProvider.GetRequiredService<ITokenfomo>();
            var result2 = await fomoService.GetBscTokensAsync();

            var pService = _serviceProvider.GetRequiredService<IPancakseSwap>();
            var result = await pService.GetSummaryAsync();
        }

        private static void RegisterServices() {
            var services = new ServiceCollection();
            services.AddSingleton<IPancakseSwap, PancakeSwap>();
            services.AddSingleton<ITokenSniffer, TokenSniffer>();
            services.AddSingleton<ITokenfomo, Tokenfomo>();
            services.AddHttpClient();
            
            _serviceProvider = services.BuildServiceProvider(true);
        }
    }
}
