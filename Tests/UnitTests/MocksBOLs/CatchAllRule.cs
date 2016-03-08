using Contract;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MocksBOLs
{

    public class CatchAllRule : IRulesBOL
    {

        public List<AssemblyConfigDTO> GetAssemblyConfig()
        {
            List<AssemblyConfigDTO> assemblyList = new List<AssemblyConfigDTO>();


            #region Default rule that sums remaining amounts
            AssemblyConfigDTO config = new AssemblyConfigDTO()
            {
                ID = 1,
                Name = "Catch All",
                FilePath = System.IO.Path.GetFullPath(@"..\..\..\..\Rules\CatchAll\bin\Debug\CatchAll.dll"),
                Type = "CatchAll.CatchAll",
                Args = new List<ConstructorArgsDTO>(),
                ProcessOrder = 99
            };

            assemblyList.Add(config);

            #endregion

            return assemblyList;
        }

    }
}
