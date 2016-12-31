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
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Configure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Reading Production Config...");
            dynamic productionConfig = JsonConvert.DeserializeObject(File.ReadAllText(args[0]));
            InsertProductionDataset(productionConfig);
            Console.ReadLine();
        }

        private static async void InsertProductionDataset(dynamic config)
        {
            Console.WriteLine("Creating Production Dataset...");

            MongoConnection<Production>.RegisterTypes();
            var mongoClient = new MongoClient("mongodb://192.168.1.101:27017");
            var database = mongoClient.GetDatabase("kitchen");
            var primerDatabase = mongoClient.GetDatabase("prismdb");
            database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();
            
            var production = new Production { Name = config.name.ToString() };
            Console.WriteLine($"Production name: {production.Name}");

            var takes = new List<Take>();
            var sessions = primerDatabase.GetCollection<BsonDocument>("sessions").AsQueryable();
            var cameras = new Dictionary<string, Uri>();
            foreach (var session in sessions)
            {
                var take = new Take
                {
                    Name = session["sessionName"].AsString,
                    Media = (await Task.WhenAll(session["recordings"].AsBsonArray.Select(async m =>
                    {
                        var name = m["name"].AsString;
                        var mpd = m["mpd"].AsString;

                        if (!cameras.ContainsKey(name))
                        {
                            Console.WriteLine($"Url for camera ({name}, {mpd}): ");
                            cameras[name] = new Uri(Console.ReadLine());
                        }

                        var url = new Uri(mpd);
                        url = new Uri(cameras[name].AbsoluteUri + '/' + webMediaPrefix + "/" +
                                string.Join("", url.Segments.Take(url.Segments.Length - 1))
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
                                    Name = name,
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

                if (productionDate.Date == take.Media.First().StartTime.Date)
                {
                    takes.Add(take);
                }
                else
                {
                    Console.WriteLine($"Ignoring take: {take.Name} - {take.Media.First().StartTime.Date}");
                }
            }
            production.Takes = takes;

            Console.WriteLine($"Path to Smappee Appliance Config: {smappeePath}");
            var smappeeConfig = new List<Appliance>();
            var applianceJson = File.ReadAllText(smappeePath);
            dynamic appliances = JsonConvert.DeserializeObject(applianceJson);
            foreach (var item in appliances.appliances)
            {
                smappeeConfig.Add(new Appliance
                {
                    Id = int.Parse(item.id.ToString()),
                    Name = item.name.ToString()
                });
            }
            production.SmappeeConfig = smappeeConfig;
            
            Console.WriteLine($"Path to Rfid Config: {rfidPath}");
            production.RfidConfig = new Dictionary<string, string>();
            var rfidJson = File.ReadAllText(rfidPath);
            dynamic rfid = JsonConvert.DeserializeObject(rfidJson);
            foreach (var item in rfid)
            {
                production.RfidConfig.Add(item.transponder.ToString(), item.item.ToString());
            }

            Console.WriteLine($"Path to Wax3 Config: {wax3Path}");
            production.Wax3Config = new Dictionary<int, string>();
            var wax3Json = File.ReadAllText(wax3Path);
            dynamic wax3 = JsonConvert.DeserializeObject(wax3Json);
            foreach (var item in wax3)
            {
                production.Wax3Config.Add(int.Parse(item.deviceId.ToString()), item.item.ToString());
            }

            Console.WriteLine($"Path to Area Config: {areaPath}");
            var areas = new List<Area>();
            var areaJson = File.ReadAllText(areaPath);
            dynamic area = JsonConvert.DeserializeObject(areaJson);
            foreach (var item in area)
            {
                var newArea = new Area
                {
                    Id = Guid.NewGuid(),
                    GTRegionStart = item.gtRegionStart,
                    GTRegionStop = item.gtRegionStop
                };

                var presentationPads = new List<string>();
                foreach (var pres in item.presentationPads)
                {
                    presentationPads.Add(pres.ToString());
                }

                var locations = new List<string>();
                foreach (var location in item.locations)
                {
                    locations.Add(location.ToString());
                }

                var rfidPads = new List<string>();
                foreach (var pad in item.rfidPads)
                {
                    rfidPads.Add(pad.ToString());
                }

                newArea.PresentationPads = presentationPads;
                newArea.Locations = locations;
                newArea.RfidPads = rfidPads;

                areas.Add(newArea);
            }
            production.AreaConfig = areas;
            
            Console.WriteLine("Creating Production...");
            var productions = database.GetCollection<Production>("Production");
            productions.InsertOne(production);
            Console.WriteLine("Finished Creating Production.");
        }
    }
}
