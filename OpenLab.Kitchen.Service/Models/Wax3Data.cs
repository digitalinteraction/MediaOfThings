namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3Data : DataModel
    {
        public int DeviceId { get; set; }

        public float AccX { get; set; }

        public float AccY { get; set; }

        public float AccZ { get; set; }

        public override string IdString()
        {
            return DeviceId.ToString();
        }
    }
}
