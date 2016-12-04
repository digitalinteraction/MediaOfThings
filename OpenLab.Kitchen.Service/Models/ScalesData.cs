namespace OpenLab.Kitchen.Service.Models
{
    public class ScalesData : DataModel
    {
        public int DeviceId { get; set; }

        public float Weight { get; set; }

        public override string IdString()
        {
            return DeviceId.ToString();
        }
    }
}
