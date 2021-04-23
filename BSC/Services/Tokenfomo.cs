using BSC.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static BSC.Models.TokenSnifferJsonModel;

namespace BSC.Services {
    public class Tokenfomo : ITokenfomo {
        const string TokenFomoUrl = "https://tokenfomo.io/";
        private readonly IServiceProvider _serviceProvider;

        public Tokenfomo(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task<IList<Models.TokenfomoResponse.Token>> GetBscTokensAsync() {
            var tokenSnifferSource = await GetTokenSnifferSourceAsync().ConfigureAwait(false);

            var rawJsonData = GetJsonFromSource(tokenSnifferSource);
            var jsonData = JsonConvert.DeserializeObject<Models.TokenfomoResponse.Root>(rawJsonData);

            return jsonData.Props.PageProps.Tokens;
        }

        private async Task<string> GetTokenSnifferSourceAsync() {
            var httpClient = _serviceProvider.GetHttpClient();
            using HttpResponseMessage response = await httpClient.GetAsync(TokenFomoUrl);
            using var content = response.Content;
            string result = await content.ReadAsStringAsync();
            return result;
        }

        private string GetJsonFromSource(string tokenSnifferSource) {
            var regex = new System.Text.RegularExpressions.Regex(@"\<script\s?.*?\>((.|\r\n)+?)\<\/script\>");
            var v = regex.Match(tokenSnifferSource);
            return v.Value.Replace(@"<script id=""__NEXT_DATA__"" type=""application/json"">", "").Replace("</script>", "");
        }
    }

    public interface ITokenfomo {
        Task<IList<Models.TokenfomoResponse.Token>> GetBscTokensAsync();
    }
}
