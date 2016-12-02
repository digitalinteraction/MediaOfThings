using System;
using System.Collections.Generic;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OpenLab.Kitchen.Repository;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.CV.Position
{
    class Program
    {
        const double MinArea = 1000;
        const string WindowName = "Feed";
        const string CameraName = "4";
        static readonly Size Resolution = new Size(500, 281);
        static readonly Rectangle ROI = new Rectangle(0, 191, 485, 90);

        static void Main(string[] args)
        {
            IReadOnlyRepository<Production> productionRepository = new MongoRepository<Production>("mongodb://192.168.1.101/kitchen", "Production");
            IReadWriteRepository<GTLocation> locationRepository = new MongoRepository<GTLocation>("mongodb://192.168.1.101/kitchen", "GTLocation");

            Console.WriteLine("Retrieving Productions...");
            var productions = productionRepository.GetAll();
            Console.WriteLine("Loading Reference Frame...");
            var reference = new Mat(args[0], LoadImageType.AnyColor);
            var resize = new Mat();
            CvInvoke.Resize(reference, resize, Resolution);

            var referenceGrey = new Mat();
            CvInvoke.CvtColor(resize, referenceGrey, ColorConversion.Bgr2Gray);
            var referenceBlur = new Mat();
            CvInvoke.GaussianBlur(referenceGrey, referenceBlur, new Size(21, 21), 0);

            foreach (var production in productions)
            {
                Console.WriteLine($"Processing Production: {production.Name}");
                foreach (var take in production.Takes)
                {
                    Console.WriteLine($"    Processing Take: {take.Name}");
                    try
                    {
                        locationRepository.InsertMany(ProcessTake(take, referenceBlur));
                        Console.WriteLine($"\nFinished Processing: {take.Name}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"    Unable to process capture: {take.Name} - {e.Message}:{e.StackTrace}");
                    }
                }
            }

            Console.WriteLine("Finished Processing!");
            Console.ReadLine();
        }

        private static IEnumerable<GTLocation> ProcessTake(Take take, Mat reference)
        {
            var media = take.Media.Single(m => m.Name == CameraName);
            var camera = new Capture(media.Url.AbsoluteUri + "full_720p.mp4");
            var gtLocations = new List<GTLocation>();

            CvInvoke.NamedWindow(WindowName);
            CvInvoke.NamedWindow("Reference");
            CvInvoke.NamedWindow("Delta");

            var frame = new Mat();
            var resize = new Mat();
            var delta = new Mat();
            var grey = new Mat();
            var blur = new Mat();
            var thresh = new Mat();
            var dilate = new Mat();

            camera.Start();
            var frameCount = camera.GetCaptureProperty(CapProp.FrameCount);
            var fps = camera.GetCaptureProperty(CapProp.Fps);
            var frameNumber = 0;

            camera.ImageGrabbed += (sender, eventArgs) =>
            {
                try
                {
                    Console.Write($"\r    Processing frame: {frameNumber}/{frameCount}");
                    camera.Retrieve(frame);
                    CvInvoke.Resize(frame, resize, Resolution);
                
                    CvInvoke.CvtColor(resize, grey, ColorConversion.Bgr2Gray);
                    CvInvoke.GaussianBlur(grey, blur, new Size(21, 21), 0);

                    CvInvoke.AbsDiff(reference, blur, delta);
                    CvInvoke.Threshold(delta, thresh, 25, 255, ThresholdType.Binary);
                    CvInvoke.Rectangle(thresh, new Rectangle(0, 0, Resolution.Width, Resolution.Height - ROI.Height), new MCvScalar(0), -1);

                    CvInvoke.Imshow("Reference", reference);

                    CvInvoke.Dilate(thresh, dilate, null, Point.Empty, 0, BorderType.Default, new MCvScalar());
                    CvInvoke.Imshow("Delta", dilate);
                    VectorOfVectorOfPoint conts = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(dilate, conts, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                    for (var i = 0; i < conts.Size; i++)
                    {
                        if (CvInvoke.ContourArea(conts[i]) < MinArea) continue;
                        var rect = CvInvoke.BoundingRectangle(conts[i]);
                        CvInvoke.Rectangle(resize, rect, new MCvScalar(0, 255), 2);
                        CvInvoke.Rectangle(resize, ROI, new MCvScalar(255), 2);
                        CvInvoke.Imshow(WindowName, resize);

                        var location = new GTLocation
                        {
                            Timestamp = media.StartTime.AddSeconds(frameNumber/fps),
                            Position = new Rect
                            {
                                X = (float) rect.X/frame.Width,
                                Y = (float) rect.Y/frame.Height,
                                Width = (float) rect.Width/frame.Width,
                                Height = (float) rect.Height/frame.Height
                            }
                        };

                        location.Estimated = location.Position.X + location.Position.Width/2;

                        gtLocations.Add(location);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"    Unable to process capture: {take.Name} - {e.Message}:{e.StackTrace}");
                }

                frameNumber++;
            };

            while (frameNumber < frameCount)
            {
                CvInvoke.WaitKey(100);
            }

            camera.Stop();
            camera.Dispose();

            return gtLocations;
        }
    }
}
