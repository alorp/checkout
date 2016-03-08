using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace CatchAll
{
    public class CatchAll : IRule
    {       
        public RulesResultDTO Calculate(List<SKUDTO> skuList)
        {
            RulesResultDTO results = new RulesResultDTO();

            if (skuList != null)
                results.Price = skuList.Sum(t => t.Price);

            results.MatchedItems = skuList;
            results.NonMatchedItems = new List<SKUDTO>();

            return results;
        }
    }
}
