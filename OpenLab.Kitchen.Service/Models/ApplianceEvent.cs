namespace OpenLab.Kitchen.Service.Models
{
    public class ApplianceEvent : DataModel
    {
        public int ApplianceId { get; set; }

        public int WattChange { get; set; }

        public override string IdString()
        {
            return ApplianceId.ToString();
        }
    }
}
