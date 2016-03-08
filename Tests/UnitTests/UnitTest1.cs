using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contract;
using UnitTests.MocksBOLs;
using SKUCheckout.Classes;
using System.Collections.Generic;
using DTO;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CatchAlland2SKURules_WithAandBs()
        {
            IRulesBOL rulesBOL = new MultiAndCatchAllBOL();
            ILoader rulesLoader = new RulesLoader();

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);

            var co = new SKUCheckout.Classes.CheckOut(rules);

            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });

            Assert.AreEqual(254.99m, co.Total());
        }


        [TestMethod]
        public void CatchAlland2SKURules_WithNoItems()
        {
            IRulesBOL rulesBOL = new MultiAndCatchAllBOL();
            ILoader rulesLoader = new RulesLoader();

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);

            var co = new SKUCheckout.Classes.CheckOut(rules);

            Assert.AreEqual(0m, co.Total());
        }

        [TestMethod]
        public void CatchAlland2SKURule_With1A()
        {
            IRulesBOL rulesBOL = new MultiAndCatchAllBOL();
            ILoader rulesLoader = new RulesLoader();

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);

            var co = new SKUCheckout.Classes.CheckOut(rules);

            co.Scan(new SKUDTO() { Name = "A", Price = 50 });

            Assert.AreEqual(50m, co.Total());
        }


        [TestMethod]
        public void CatchAlland2SKURule_WithMutiplieMatchingRules()
        {
            IRulesBOL rulesBOL = new MultiAndCatchAllBOL();
            ILoader rulesLoader = new RulesLoader();

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);

            var co = new SKUCheckout.Classes.CheckOut(rules);

            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });

            Assert.AreEqual(309.98m, co.Total());
        }


        [TestMethod]
        public void CatchAlland2SKURule_WithNoMatchingMultiRules()
        {
            IRulesBOL rulesBOL = new MultiAndCatchAllBOL();
            ILoader rulesLoader = new RulesLoader();

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);

            var co = new SKUCheckout.Classes.CheckOut(rules);

            co.Scan(new SKUDTO() { Name = "C", Price = 10 });
            co.Scan(new SKUDTO() { Name = "D", Price = 20 });


            Assert.AreEqual(30, co.Total());
        }


        [TestMethod]
        public void CatchAllRuleOnly_WithAandBs()
        {
            IRulesBOL rulesBOL = new CatchAllRule();
            ILoader rulesLoader = new RulesLoader();

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);

            var co = new SKUCheckout.Classes.CheckOut(rules);

            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "B", Price = 20 });
            co.Scan(new SKUDTO() { Name = "A", Price = 50 });

            Assert.AreEqual(290m, co.Total());
        }


        [TestMethod]
        public void CatchAllRuleOnly_WithNoItems()
        {
            IRulesBOL rulesBOL = new CatchAllRule();
            ILoader rulesLoader = new RulesLoader();

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);

            var co = new SKUCheckout.Classes.CheckOut(rules);

            Assert.AreEqual(0m, co.Total());
        }


        [TestMethod]
        public void CatchAllRuleOnly_With1A()
        {
            IRulesBOL rulesBOL = new CatchAllRule();
            ILoader rulesLoader = new RulesLoader();

            List<IRule> rules = rulesLoader.GetRules(rulesBOL);
            
            var co = new SKUCheckout.Classes.CheckOut(rules);

            co.Scan(new SKUDTO() { Name = "A", Price = 50 });

            Assert.AreEqual(50m, co.Total());
        }

    }
}
