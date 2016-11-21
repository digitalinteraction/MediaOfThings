using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.Windows.Documents.DocumentStructures;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenLab.Kitchen.Repository;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.CV.Position
{
    class Program
    {
        const double MinArea = 500;
        const string WindowName = "Feed";
        const string CameraName = "4";
        static readonly Rectangle ROI = new Rectangle(0, 500, 1280, 220);

        static void Main(string[] args)
        {
            IReadOnlyRepository<Production> productionRepository = new MongoRepository<Production>("mongodb://192.168.1.101/kitchen", "Productions");

            Console.WriteLine("Retrieving Productions...");
            var productions = productionRepository.GetAll();
            Console.WriteLine("Loading Reference Frame...");
            var reference = new Mat(args[0], LoadImageType.AnyColor);

            var referenceGrey = new Mat();
            CvInvoke.CvtColor(reference, referenceGrey, ColorConversion.Bgr2Gray);
            var referenceBlur = new Mat();
            CvInvoke.GaussianBlur(referenceGrey, referenceBlur, new Size(21, 21), 0);

            foreach (var production in productions)
            {
                Console.WriteLine($"Processing Production: {production.Name}");
                foreach (var take in production.Takes)
                {
                    Console.WriteLine($"    Processing Take: {take.Name}");
                    ProcessTake(take, referenceBlur);
                }
            }
        }

        private static void ProcessTake(Take take, Mat reference)
        {
            var camera = new Capture(take.Media.Single(m => m.Name == CameraName).Url.AbsoluteUri + "full_720p.mp4");

            CvInvoke.NamedWindow(WindowName);

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

                    CvInvoke.AbsDiff(reference, blur, delta);
                    CvInvoke.Threshold(delta, thresh, 25, 255, ThresholdType.Binary);

                    CvInvoke.Dilate(thresh, dilate, null, Point.Empty, 0, BorderType.Default, new MCvScalar());

                    VectorOfVectorOfPoint conts = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(dilate, conts, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                    for (var i = 0; i < conts.Size; i++)
                    {
                        if (CvInvoke.ContourArea(conts[i]) < MinArea) continue;
                        var rect = CvInvoke.BoundingRectangle(conts[i]);
                        if (!ROI.IntersectsWith(rect) && !ROI.Contains(rect)) return;
                        CvInvoke.Rectangle(frame, rect, new MCvScalar(0, 255), 2);
                        CvInvoke.Rectangle(frame, ROI, new MCvScalar(255), 2);
                        CvInvoke.Imshow(WindowName, frame);
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
