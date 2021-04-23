using BSC.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BSC.Services {
    public class PancakeSwap : IPancakseSwap {
        public const string ApiUrl = "https://api.pancakeswap.info/api/";
        private readonly IServiceProvider _serviceProvider;

        public PancakeSwap(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task<Dictionary<string, Models.Pancakeswap.SummaryResponse>> GetSummaryAsync() {
            var httpClient = _serviceProvider.GetHttpClient();
            var content = await httpClient.GetStringAsync($"{ApiUrl}summary");
            return JsonConvert.DeserializeObject<Dictionary<string, Models.Pancakeswap.SummaryResponse>>(content);
        }
    }

    public interface IPancakseSwap {
        Task<Dictionary<string, Models.Pancakeswap.SummaryResponse>> GetSummaryAsync();
    }
}
