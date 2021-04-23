using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSC.Models
{
    public class TokenfomoResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Token {
            [JsonProperty("addr")]
            public string Addr { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("blockNum")]
            public int BlockNum { get; set; }

            [JsonProperty("blockTime")]
            public int BlockTime { get; set; }

            [JsonProperty("chainId")]
            public string ChainId { get; set; }
        }

        public class PageProps {
            [JsonProperty("tokens")]
            public List<Token> Tokens { get; set; }
        }

        public class Props {
            [JsonProperty("pageProps")]
            public PageProps PageProps { get; set; }

            [JsonProperty("__N_SSP")]
            public bool NSSP { get; set; }
        }

        public class Query {
        }

        public class Root {
            [JsonProperty("props")]
            public Props Props { get; set; }

            [JsonProperty("page")]
            public string Page { get; set; }

            [JsonProperty("query")]
            public Query Query { get; set; }

            [JsonProperty("buildId")]
            public string BuildId { get; set; }

            [JsonProperty("isFallback")]
            public bool IsFallback { get; set; }

            [JsonProperty("gssp")]
            public bool Gssp { get; set; }

            [JsonProperty("customServer")]
            public bool CustomServer { get; set; }
        }


    }
}
