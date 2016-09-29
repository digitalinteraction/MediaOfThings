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
            Console.Write("Enter a name for capture session: ");
            var recorder = new SessionRecorder(Console.ReadLine());
            recorder.StartCapture();

            Console.ReadLine();
            recorder.StopCapture();
        }
    }
}
