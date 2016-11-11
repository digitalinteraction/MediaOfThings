using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public abstract class DataModel : Model
    {
        public DateTime Timestamp { get; set; }

        public abstract string DeviceIdString();
    }
}
