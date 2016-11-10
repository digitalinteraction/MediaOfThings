using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenLab.Kitchen.Recogniser.Library;
using OpenLab.Kitchen.Service.Models;
using OpenLab.Kitchen.StreamingRepository;
using OpenLab.Kitchen.Recogniser.Library.AnalysisModels;

namespace OpenLab.Kitchen.Recogniser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var wax3Messages = new Wax3Streamer();
            var wax3Recogniser = new Wax3Recogniser();
            var wax3 = new StreamManager<Wax3Data, int, Wax3State>(wax3Messages, wax3Recogniser);
        }
    }
}
