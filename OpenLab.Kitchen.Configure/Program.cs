using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using OpenLab.Kitchen.Repository;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;
using OpenLab.Kitchen.Service.Values;

namespace OpenLab.Kitchen.Configure
{
    public class Program
    {
        private const string ConnectionString = "mongodb://192.168.1.101:27017/kitchen";

        public static void Main(string[] args)
        {
            Console.WriteLine("Reading Production Config...");
            dynamic productionConfig = JsonConvert.DeserializeObject<ProductionJson>(File.ReadAllText(args[0]));
            InsertProductionDataset(productionConfig);
            Console.ReadLine();
        }

        private static async void InsertProductionDataset(ProductionJson config)
        {
            Console.WriteLine("Creating Production Dataset...");
            Console.WriteLine("Opening PrimerDB Connection...");

            MongoConnection<Production>.RegisterTypes();
            var mongoClient = new MongoClient("mongodb://192.168.1.101:27017");
            var database = mongoClient.GetDatabase("kitchen");
            var primerDatabase = mongoClient.GetDatabase("prismdb");
            database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            Console.WriteLine("Opening Production Database Connection...");
            IReadWriteRepository<Production> productionRepository = new MongoRepository<Production>(ConnectionString);
            
            var production = new Production { Name = config.Name };
            Console.WriteLine($"Production name: {production.Name}");

            var takes = new List<Take>();
            var sessions = primerDatabase.GetCollection<BsonDocument>("sessions").AsQueryable();
            var cameras = new List<Camera>();

            foreach (var session in sessions)
            {
                var take = new Take
                {
                    Name = session["sessionName"].AsString,
                    Media = (await Task.WhenAll(session["recordings"].AsBsonArray.Select(async m =>
                    {
                        var name = m["name"].AsString;
                        var mpd = new Uri(m["mpd"].AsString);

                        var recordingLocation = mpd.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
                        var cameraConfig = config.CameraConfig.SingleOrDefault(c => c.PrimerLocation.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped) == recordingLocation);

                        if (cameraConfig == default(CameraConfig))
                        {
                            Console.WriteLine($"Url for camera ({name}, {recordingLocation}): ");
                            var replayLocation = new Uri(Console.ReadLine());
                            cameraConfig = new CameraConfig { Id = Guid.NewGuid(), Name = name, PrimerLocation = mpd, ReplayLocation = replayLocation };
                            config.CameraConfig = new List<CameraConfig>(config.CameraConfig) { cameraConfig }.ToArray();
                        }

                        var camera = cameras.SingleOrDefault(c => c.Id == cameraConfig.Id);

                        if (camera == default(Camera))
                        {
                            camera = new Camera
                            {
                                Id = cameraConfig.Id,
                                Name = cameraConfig.Name,
                                SafeShot = cameraConfig.SafeShot ?? new Rect { X = 0.0, Y = 0.0, Height = 1.0, Width = 1.0 },
                                FaceUpShots = cameraConfig.FaceUpShots ?? new Dictionary<Guid, Rect>(),
                                DetailShots = cameraConfig.DetailShots ?? new Dictionary<Guid, Rect>()
                            };

                            cameras.Add(camera);
                        }

                        var url = new Uri(cameraConfig.ReplayLocation.AbsoluteUri + "/" +
                                string.Join("", mpd.Segments.Take(mpd.Segments.Length - 1))
                                .TrimStart(Path.AltDirectorySeparatorChar));

                        var request = WebRequest.Create(url + "playback.mpd");
                        try
                        {
                            var response = (HttpWebResponse) await request.GetResponseAsync();
                            using (var stream = new StreamReader(response.GetResponseStream()))
                            {
                                var manifest = new XmlDocument();
                                manifest.LoadXml(stream.ReadToEnd());
                                var nodes = manifest.GetElementsByTagName("MPD");

                                var startTime = DateTime.Parse(nodes[0].Attributes["availabilityStartTime"].Value);

                                return new Media
                                {
                                    CameraId = camera.Id,
                                    StartTime = startTime,
                                    Url = url
                                };
                            }
                        }
                        catch (WebException e)
                        {
                            Console.WriteLine($"Failed to Retrieve Manifest: {name} - {url} -- {e}");
                            return null;
                        }
                    }).ToList())).Where(m => m != null)
                };

                if (!take.Media.Any()) continue;

                var takeTime = take.Media.First().StartTime;

                if (!(config.StartDateTime <= takeTime && takeTime < config.EndDateTime))
                {
                    Console.WriteLine($"Ignoring take: {take.Name} - {take.Media.First().StartTime.Date}");
                    continue;
                }

                var duplicate = false;
                foreach (var media in take.Media)
                {
                    var duplicateTake = takes.SingleOrDefault(t => t.Media.Any(m => m.CameraId == media.CameraId && m.Url == media.Url));
                    if (duplicateTake != default(Take))
                    {
                        Console.WriteLine($"Combining duplicate takes: {duplicateTake.Name}, {take.Name}");
                        duplicateTake.Name += " / " + take.Name;
                        duplicate = true;
                        break;
                    }
                }

                if (!duplicate)
                {
                    takes.Add(take);
                }
            }

            production.Takes = takes;
            production.Cameras = cameras;

            Console.WriteLine("Processing Smappee Appliance Config...");
            production.SmappeeConfig = config.ApplianceConfig.Select(a => new Appliance
            {
                Id = a.DeviceId,
                Name = a.Name,
                AssociatedTransponder = a.AssociatedTransponder
            }).ToList();
            
            Console.WriteLine("Processing Rfid Config...");
            production.RfidConfig = config.RfidConfig;

            Console.WriteLine("Processing Wax3 Config...");
            production.Wax3Config = config.Wax3Config;

            Console.WriteLine("Processing Area Config...");
            production.AreaConfig = config.AreaConfig.Select(a => new Area
            {
                Id = a.Id,
                GTRegionStart = a.GtRegionStart,
                GTRegionStop = a.GtRegionStop,
                PresentationPads = a.PresentationPads,
                Locations = a.Locations,
                RfidPads = a.RfidPads
            }).ToList();
            
            Console.WriteLine("Inserting Production...");
            productionRepository.Insert(production);
            Console.WriteLine("Finished Creating Production.");
        }
    }
}
