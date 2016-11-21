using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace OpenLab.Kitchen.CV.Position
{
    class Program
    {
        const double MinArea = 500;

        static void Main(string[] args)
        {
            var camera = new Capture("lowcrop.mp4");

            CvInvoke.NamedWindow("test");

            Mat firstFrameGrey = new Mat();
            Mat firstFrame = new Mat();
            CvInvoke.CvtColor(new Mat("Capture.PNG", LoadImageType.AnyColor), firstFrameGrey, ColorConversion.Bgr2Gray);
            CvInvoke.GaussianBlur(firstFrameGrey, firstFrame, new Size(21, 21), 0);

            var frame = new Mat();
            var delta = new Mat();
            var grey = new Mat();
            var blur = new Mat();
            var thresh = new Mat();
            var dilate = new Mat();

            camera.Start();

            camera.ImageGrabbed += (sender, eventArgs) =>
            {
                camera.Retrieve(frame);
                try
                {
                    CvInvoke.CvtColor(frame, grey, ColorConversion.Bgr2Gray);
                    CvInvoke.GaussianBlur(grey, blur, new Size(21, 21), 0);

                    CvInvoke.AbsDiff(firstFrame, blur, delta);
                    CvInvoke.Threshold(delta, thresh, 25, 255, ThresholdType.Binary);

                    CvInvoke.Dilate(thresh, dilate, null, Point.Empty, 0, BorderType.Default, new MCvScalar());

                    VectorOfVectorOfPoint conts = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(dilate, conts, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                    CvInvoke.Imshow("test", delta);

                    for (var i = 0; i < conts.Size; i++)
                    {
                        if (CvInvoke.ContourArea(conts[i]) < MinArea) continue;

                        var rect = CvInvoke.BoundingRectangle(conts[i]);
                        CvInvoke.Rectangle(frame, rect, new MCvScalar(0, 255), 2);
                        CvInvoke.Imshow("test", frame);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            };

            CvInvoke.WaitKey();
        }
    }
}
