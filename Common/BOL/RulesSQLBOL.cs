using Contract;
using System;
using System.Collections.Generic;

namespace BOL
{
    public class RulesSQLBOL : IRulesBOL
    {
        /// <summary>
        /// Place holder to get settings from database instaead of the Fake BOL
        /// </summary>
        /// <returns></returns>
        public List<DTO.AssemblyConfigDTO> GetAssemblyConfig()
        {
            throw new NotImplementedException();
        }
    }
}
