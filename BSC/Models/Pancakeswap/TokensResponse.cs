using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSC.Models.Pancakeswap
{
    public static class TokensResponse
    {
        public class Root {
            [JsonProperty("updated_at")]
            public long UpdatedAt { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public class Data {
            [JsonProperty]
            public Dictionary<string, Token> Tokens { get; set; }
        }

        public class Token {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("price")]
            public string Price { get; set; }

            [JsonProperty("price_BNB")]
            public string PriceBNB { get; set; }
        }
    }
}
