using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Kitchen.Recogniser.Library.AnalysisModels
{
    public class Wax3State
    {
        public bool Alive { get; set; }

        public DateTime LastAlive { get; set; }

        public double TimeAlive { get; set; }

        public float Noise { get; set; }
    }
}
