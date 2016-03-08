using Contract;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MocksBOLs
{
    public class MultiAndCatchAllBOL : IRulesBOL
    {
        public List<AssemblyConfigDTO> GetAssemblyConfig()
        {
            List<AssemblyConfigDTO> assemblyList = new List<AssemblyConfigDTO>();

            #region Multi SKU Rule for A
            AssemblyConfigDTO config = new AssemblyConfigDTO()
            {
                ID = 1,
                Name = "Multi",
                FilePath = System.IO.Path.GetFullPath(@"..\..\..\..\Rules\Multi\bin\Debug\Multi.dll"),
                Type = "Multi.MultiRule",
                Args = new List<ConstructorArgsDTO>(),
                ProcessOrder = 1
            };

            config.Args.Add(new ConstructorArgsDTO() { Name = "Quantity", ValueInt = 3, Order = 1 });
            config.Args.Add(new ConstructorArgsDTO() { Name = "Price", ValueDecimal = 124.99m, Order = 2 });
            config.Args.Add(new ConstructorArgsDTO() { Name = "Item Name", ValueString = "A", Order = 3 });

            assemblyList.Add(config);

            #endregion

            #region Multi SKU Rule for B
            config = new AssemblyConfigDTO()
            {
                ID = 1,
                Name = "Multi",
                FilePath = System.IO.Path.GetFullPath(@"..\..\..\..\Rules\Multi\bin\Debug\Multi.dll"),
                Type = "Multi.MultiRule",
                Args = new List<ConstructorArgsDTO>(),
                ProcessOrder = 2
            };

            config.Args.Add(new ConstructorArgsDTO() { Name = "Quantity", ValueInt = 2, Order = 1 });
            config.Args.Add(new ConstructorArgsDTO() { Name = "Price", ValueDecimal = 30, Order = 2 });
            config.Args.Add(new ConstructorArgsDTO() { Name = "Item Name", ValueString = "B", Order = 3 });

            assemblyList.Add(config);

            #endregion

            #region Default rule that sums remaining amounts
            config = new AssemblyConfigDTO()
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
