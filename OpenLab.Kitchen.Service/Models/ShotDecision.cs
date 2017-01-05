using System;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Values;

namespace OpenLab.Kitchen.Service.Models
{
    public class ShotDecision : TimeModel, IStreamingModel
    {
        public Guid CameraId { get; set; }

        public Rect Frame { get; set; }

        public string RoutingKey()
        {
            return CameraId.ToString();
        }
    }
}
