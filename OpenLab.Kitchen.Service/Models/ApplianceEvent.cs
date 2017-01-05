using System;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class ApplianceEvent : TimeModel, IStreamingModel, IDataModel
    {
        public int ApplianceId { get; set; }

        public int WattChange { get; set; }

        public string IdString()
        {
            return ApplianceId.ToString();
        }

        public string RoutingKey()
        {
            return IdString();
        }
    }
}
