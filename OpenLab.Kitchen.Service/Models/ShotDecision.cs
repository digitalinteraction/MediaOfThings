using System;
using OpenLab.Kitchen.Service.Values;

namespace OpenLab.Kitchen.Service.Models
{
    public class ShotDecision : TimeModel
    {
        public Guid CameraId { get; set; }

        public Rect Frame { get; set; }
    }
}
