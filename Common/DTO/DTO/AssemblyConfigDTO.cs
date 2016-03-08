using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AssemblyConfigDTO
    {
        public int ID { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public List<ConstructorArgsDTO> Args { get; set; }
        public int ProcessOrder { get; set; }
    }
}
