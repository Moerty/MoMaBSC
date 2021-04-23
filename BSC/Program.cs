using Newtonsoft.Json;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace BSC {
    class Program {
        const string TokenSnifferUrl = "https://tokensniffer.com/tokens/new";
        static void Main(string[] args) {
            using var webClient = new WebClient();

            var tokenSnifferSource = webClient.DownloadString(TokenSnifferUrl);

            var rawJsonData = GetJsonFromSource(tokenSnifferSource);
            var jsonData = JsonConvert.DeserializeObject<Models.TokenSnifferJsonModel.Root>(rawJsonData);

            var bscTokens = jsonData.props.pageProps.bscTokens;
        }

        private static string GetJsonFromSource(string tokenSnifferSource) {
            var regex = new System.Text.RegularExpressions.Regex(@"\<script\s?.*?\>((.|\r\n)+?)\<\/script\>");
            var v = regex.Match(tokenSnifferSource);
            return v.Value.Replace(@"<script id=""__NEXT_DATA__"" type=""application/json"">", "").Replace("</script>", "");

            //string output = System.Text.RegularExpressions.Regex.Replace(input, "<Video>(.*)</Video>", string.Format("<Video>www.test.com</Video>"))
        }
    }
}
