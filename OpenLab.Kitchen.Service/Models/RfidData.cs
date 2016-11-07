namespace OpenLab.Kitchen.Service.Models
{
    public class RfidData : DataModel
    {
        public string DeviceId { get; set; }

        public string[] Transponders { get; set; }
    }
}