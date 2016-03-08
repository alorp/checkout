using Contract;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi
{
    public class MultiRule : IRule
    {

        private int quantity { get; set; }
        private decimal price { get; set; }
        private string itemName { get; set; }

        public MultiRule(int quantity, decimal price, string itemName)
        {
            this.quantity = quantity;
            this.price = price;
            this.itemName = itemName;
        }

        public RulesResultDTO Calculate(List<SKUDTO> skuList)
        {
            RulesResultDTO result = new RulesResultDTO();
            result.MatchedItems = new List<SKUDTO>();
            result.NonMatchedItems = new List<SKUDTO>();

            if (skuList == null)
                return result;

            List<SKUDTO> matchingItems = skuList.Where(t => t.Name == itemName).ToList();

            //To do - Need to check for divide by zero 
            int numberOfMatches = matchingItems.Count / quantity;
           
            if (numberOfMatches > 0)
            {
                result.Price = price * numberOfMatches;
                foreach (SKUDTO skuItem in skuList)
                {
                    if (skuItem.Name == itemName && result.MatchedItems.Count < quantity * numberOfMatches)
                        result.MatchedItems.Add(skuItem);
                    else
                        result.NonMatchedItems.Add(skuItem);
                }
            }
            else
                result.NonMatchedItems = skuList;

            return result;
        }

    }
}
