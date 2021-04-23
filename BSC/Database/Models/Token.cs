using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSC.Database.Models {
    public class Token {
        public string Id { get; set; }
        public long UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public float Price { get; set; }
        public float Price_BNB { get; set; }
    }
}
