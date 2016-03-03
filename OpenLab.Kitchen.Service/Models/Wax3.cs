using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3
    {
        int DeviceId { get; set; }

        int Channel { get; set; }

        IQueryable<Wax3Data> SensorData { get; set; }
    }
}
