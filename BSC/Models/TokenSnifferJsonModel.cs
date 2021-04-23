using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSC.Models {
    public static class TokenSnifferJsonModel {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class EthToken {
            public string addr { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
            public bool defunct { get; set; }
            public string image_url { get; set; }
            public string homepage_url { get; set; }
            public string forum_url { get; set; }
            public string chat_url { get; set; }
            public string announcement_url { get; set; }
            public string code_url { get; set; }
            public string twitter_name { get; set; }
            public DateTime created_at { get; set; }
            public object network { get; set; }
            public bool has_source_code { get; set; }
            public bool autoflag { get; set; }
            public string source_md5 { get; set; }
            public object exploit_id { get; set; }
        }

        public class BscToken {
            public string addr { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
            public bool defunct { get; set; }
            public string image_url { get; set; }
            public string homepage_url { get; set; }
            public string forum_url { get; set; }
            public string chat_url { get; set; }
            public string announcement_url { get; set; }
            public string code_url { get; set; }
            public string twitter_name { get; set; }
            public DateTime created_at { get; set; }
            public string network { get; set; }
            public bool has_source_code { get; set; }
            public bool autoflag { get; set; }
            public string source_md5 { get; set; }
            public object exploit_id { get; set; }
        }

        public class PageProps {
            public List<EthToken> ethTokens { get; set; }
            public List<BscToken> bscTokens { get; set; }
        }

        public class Props {
            public PageProps pageProps { get; set; }
            public bool __N_SSG { get; set; }
        }

        public class Query {
        }

        public class Root {
            public Props props { get; set; }
            public string page { get; set; }
            public Query query { get; set; }
            public string buildId { get; set; }
            public bool nextExport { get; set; }
            public bool isFallback { get; set; }
            public bool gsp { get; set; }
            public List<List<object>> head { get; set; }
        }


    }
}
