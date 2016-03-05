using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Capture
{
    class Program
    {
        static void Main(string[] args)
        {
            var recorder = new SessionRecorder();
            recorder.StartCapture();

            Console.ReadLine();
            recorder.StopCapture();
        }
    }
}
