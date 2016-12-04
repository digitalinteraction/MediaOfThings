using System;

namespace OpenLab.Kitchen.Service.Models
{
    public class AoiState : DataModel
    {
        public Guid AreaId { get; set; }

        public double Value { get; set; }

        public override string IdString()
        {
            return AreaId.ToString();
        }
    }
}
