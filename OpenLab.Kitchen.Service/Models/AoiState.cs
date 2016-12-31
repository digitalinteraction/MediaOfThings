using System;

namespace OpenLab.Kitchen.Service.Models
{
    public class AoiState : TimeModel
    {
        public Guid AreaId { get; set; }

        public double Value { get; set; }

        public bool Interaction { get; set; }

        public bool Presentation { get; set; }

        public DateTime PresentationStarted { get; set; }
    }
}
