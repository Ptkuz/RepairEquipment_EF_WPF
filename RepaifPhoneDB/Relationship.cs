using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepaifPhoneDB
{
    public class Relationship
    {
        public Guid ID_Performance { get; set; }
        public Guid ID_Detail { get; set; }
        public Performance? Performance { get; set; }
        public StockDetails? StockDetails { get; set; }
    }

}
