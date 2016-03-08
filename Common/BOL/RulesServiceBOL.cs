using Contract;
using DTO;
using System;
using System.Collections.Generic;

namespace BOL
{
    public class RulesServiceBOL : IRulesBOL
    {
        /// <summary>
        /// Place holder to get settings from a web/windows service instaead of the Fake BOL
        /// </summary>
        /// <returns></returns>
        public List<AssemblyConfigDTO> GetAssemblyConfig()
        {
            throw new NotImplementedException();
        }
    }
}
