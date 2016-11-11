using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class ApplianceEvent : DataModel
    {
        public int ApplianceId { get; set; }

        public int WattChange { get; set; }

        public override string DeviceIdString()
        {
            return ApplianceId.ToString();
        }
    }
}
