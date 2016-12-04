namespace OpenLab.Kitchen.Service.Models
{
    public class RfidData : DataModel
    {
        public string DeviceId { get; set; }

        public string[] Transponders { get; set; }

        public override string IdString()
        {
            return DeviceId;
        }
    }
}