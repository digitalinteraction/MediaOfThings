using System;
using System.Collections.Generic;
using OpenLab.Kitchen.Service.Values;

namespace OpenLab.Kitchen.Configure
{

    public class ProductionJson
    {
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public AreaConfig[] AreaConfig { get; set; }
        public CameraConfig[] CameraConfig { get; set; }
        public Dictionary<int, string> Wax3Config { get; set; }
        public Dictionary<string, string> RfidConfig { get; set; }
        public ApplianceConfig[] ApplianceConfig { get; set; }
    }

    public class AreaConfig
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string[] PresentationPads { get; set; }
        public float GtRegionStart { get; set; }
        public float GtRegionStop { get; set; }
        public string[] Locations { get; set; }
        public string[] RfidPads { get; set; }
    }

    public class CameraConfig
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri PrimerLocation { get; set; }
        public Uri ReplayLocation { get; set; }
        public Rect SafeShot { get; set; }
        public Dictionary<Guid, Rect> FaceUpShots { get; set; }
        public Dictionary<Guid, Rect> DetailShots { get; set; }
    }

    public class ApplianceConfig
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string AssociatedTransponder { get; set; }
    }
}
