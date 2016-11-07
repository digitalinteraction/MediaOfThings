using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class Production : Model
    {
        public string Name { get; set; }

        public IEnumerable<Take> Takes { get; set; }

        public Dictionary<string,string> RfidConfig { get; set; }

        public Dictionary<int, string> SmappeeConfig { get; set; }

        public Dictionary<int, string> Wax3Config { get; set; }
    }
}
