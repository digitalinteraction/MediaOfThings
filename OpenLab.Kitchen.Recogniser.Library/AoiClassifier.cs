using OpenLab.Kitchen.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class AoiClassifier
    {
        private DateTime Clock { get; set; }
        private readonly IDictionary<Area, double> _aoiStates;

        public AoiClassifier(DateTime startTime, IEnumerable<Area> areas)
        {
            Clock = startTime;

            _aoiStates = new Dictionary<Area, double>(areas.ToArray().Select);
        }
    }
}