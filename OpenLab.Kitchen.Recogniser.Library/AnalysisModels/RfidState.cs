using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Kitchen.Recogniser.Library.AnalysisModels
{
    public class RfidState
    {
        public Dictionary<string, DateTime> Transponders { get; set; }
    }
}
