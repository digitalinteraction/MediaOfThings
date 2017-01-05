using System;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class AoiState : TimeModel, IStreamingModel
    {
        public Guid AreaId { get; set; }

        public double Value { get; set; }

        public bool Interaction { get; set; }

        public DateTime InteractionStarted { get; set; }

        public bool Presentation { get; set; }

        public DateTime PresentationStarted { get; set; }

        public string RoutingKey()
        {
            return AreaId.ToString();
        }
    }
}