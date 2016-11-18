using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OpenLab.Kitchen.CV.Position
{
    class Program
    {
        const double MinArea = 500;

        static void Main(string[] args)
        {
            var camera = new VideoCapture("capture.mp4");
            Mat firstFrame = camera.RetrieveMat();

            var output = new VideoWriter("test.mp4", FourCC.H264, 30, firstFrame.Size());
            firstFrame.Resize(500);
            output.Write(firstFrame);

            Mat delta = firstFrame.Clone();
            Mat grey = new Mat();
            Mat blur = grey.Clone();
            Mat thresh = grey.Clone();

            using (var window = new Window("capture"))
            using(var frame = new Mat())
            {
                while (true)
                {
                    camera.Read(frame);
                    window.ShowImage(frame);
                    /*frame.Resize(500);
                    Cv2.CvtColor(frame, grey, ColorConversionCodes.BGR2GRAY);
                    Cv2.GaussianBlur(grey, blur, new Size(21, 21), 0);

                    Cv2.Absdiff(firstFrame, frame, delta);
                    Cv2.Threshold(delta, thresh, 25, 255, ThresholdTypes.Binary);

                    Cv2.Dilate(thresh, thresh, null, null, 2);

                    Mat[] conts;
                    Cv2.FindContours(thresh, out conts, null, RetrievalModes.External,
                        ContourApproximationModes.ApproxSimple);

                    foreach (var c in conts)
                    {
                        if (Cv2.ContourArea(c) < MinArea) continue;

                        var rect = Cv2.BoundingRect(c);
                        Cv2.Rectangle(frame, rect, new Scalar(0, 255), 2);

                        output.Write(frame);
                    }*/
                }
            }
        }
    }
}
