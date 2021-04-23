using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSC.Models.Pancakeswap {
    public class SummaryResponse {
        [JsonProperty("last_price")]
        public string LastPrice { get; set; }

        [JsonProperty("base_volume")]
        public string BaseVolume { get; set; }

        [JsonProperty("quote_volume")]
        public string QuoteVolume { get; set; }
        /*
        public class Size {
            public string human { get; set; }
            public int bytes { get; set; }
        }

        public class Date {
            public string human { get; set; }
            public int epoch { get; set; }
        }

        public class RootObject {
            public string name { get; set; }
            public Size size { get; set; }
            public Date date { get; set; }
        } */

        /*
         * [
        {
            "Foo": {
                "name": "Foo",      
                "size": {
                    "human": "832.73kB",
                    "bytes": 852718
                },
                "date": {
                    "human": "September 18, 2017",
                    "epoch": 1505776741
                },
            }
        },
        {
            "bar": {
                "name": "bar",
                "size": {
                    "human": "4.02MB",
                    "bytes": 4212456
                },
                "date": {
                    "human": "September 18, 2017",
                    "epoch": 1505776741
                }
            }
        }]
         * */

        //var list = JsonConvert.DeserializeObject<List<Dictionary<string, RootObject>>>(jsonString);

    }
}
