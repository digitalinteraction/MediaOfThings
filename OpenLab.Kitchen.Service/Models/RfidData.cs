using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class RfidData : Model
    {
        public DateTime DataTimeStamp { get; set; }

        public string[] Transponders { get; set; }
    }
}
