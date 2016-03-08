using BOL;
using SKUCheckout.Classes;
using Contract;
using DTO;
using System.Collections.Generic;
using System;

namespace SKUCheckout
{

    class Program
    {
        static void Main(string[] args)
        {
            IRulesBOL rulesBOL = new RulesFakeBOL();
            ILoader rulesLoader = new RulesLoader();

            /*The rules setup in the fake BOL are as follows:
                3A = 124.99
                2B = 30
            */

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);

            var co = new SKUCheckout.Classes.CheckOut(rules);

            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });

            Console.WriteLine(string.Format("Total: {0}",  co.Total()));
            Console.ReadKey();
        }
      

    }

}
