using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RulesResultDTO
    {
        public decimal Price { get; set; }
        public List<SKUDTO> MatchedItems { get; set; }
        public List<SKUDTO> NonMatchedItems { get; set; }
    }
}
