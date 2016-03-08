using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ILoader
    {
        List<IRule> GetRules(IRulesBOL rulesBOL);
    }
}
