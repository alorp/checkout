using Contract;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKUCheckout.Classes
{
    public class CheckOut
    {
        private List<IRule> pricingRules { get; set; }
        private List<SKUDTO> skuList { get; set; }

        public CheckOut(List<IRule> pricingRules)
        {
            this.pricingRules = pricingRules;
        }

        /// <summary>
        /// Add an item to the list of items to be purchased
        /// </summary>
        public void Scan(SKUDTO item)
        {
            if (skuList == null)
                skuList = new List<SKUDTO>();

            skuList.Add(item);
            DisplayScannedItem(item);
        }

        private void DisplayScannedItem(SKUDTO item)
        {
            Console.WriteLine(string.Format("Scanned: {0} @ {1}", item.Name, item.Price));
        }

        /// <summary>
        /// Calculate total cost using supplied rules
        /// </summary>
        public decimal Total()
        {
            decimal runningTotal = 0;

            var tempList = skuList;

            foreach (IRule rule in pricingRules)
            {
                RulesResultDTO result = rule.Calculate(tempList);
                runningTotal = runningTotal + result.Price;
                tempList = result.NonMatchedItems;

                //Exit loop if nothing else to process
                if (tempList == null)
                    break;
            }

            return runningTotal;
        }

    }
}
