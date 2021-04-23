using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BSC.Extensions {
    public static class ServiceProviderExtensions {
        public static HttpClient GetHttpClient(this IServiceProvider serviceProvider) {
            var scope = serviceProvider.CreateScope();
            var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient();

            return httpClient;
        }
    }
}
