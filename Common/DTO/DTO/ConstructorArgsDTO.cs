using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// To do - the constructor args are hard coded to only accept decimal, int and string. This should be made more flexible
    /// </summary>

    public class ConstructorArgsDTO
    {
        public string Name { get; set; }
        public int? ValueInt { get; set; }
        public decimal? ValueDecimal { get; set; }
        public string ValueString { get; set; }
        public int Order { get; set; }
    }
}
