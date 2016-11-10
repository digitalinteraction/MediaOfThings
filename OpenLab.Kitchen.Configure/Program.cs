using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using OpenLab.Kitchen.Repository;
using OpenLab.Kitchen.Service.Models;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace OpenLab.Kitchen.Configure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type command to start:");
            Console.WriteLine("    c     - Cleans Old Mongo records and remaps to new models.");
            Console.WriteLine("    cm    - Combines all datasets into sensor collections.");
            Console.WriteLine("    cp    - Configure new production.");
            var com = Console.ReadLine();

            switch (com)
            {
                case "c":
                    CleanMongo();
                    break;
                case "cm":
                    CombineDatasets();
                    break;
                case "cp":
                    InsertProductionDataset();
                    break;
                default:
                    Console.WriteLine("Invalid argument.");
                    Environment.Exit(0);
                    break;
            }

            Console.ReadLine();
        }

        private static void CleanMongo()
        {
            Console.WriteLine("Cleaning in progress...");

            MongoConnection.RegisterTypes();

            var mongoClient = new MongoClient("mongodb://192.168.1.101:27017");
            var database = mongoClient.GetDatabase("kitchen");

            database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            var mongoCollections = database.ListCollections();
            mongoCollections.MoveNext();

            foreach (var c in mongoCollections.Current)
            {
                Console.WriteLine($"{c["name"].AsString}: Starting Cleaning...");
                Console.WriteLine($"{c["name"].AsString}: Retrieving old records...");

                var collection = database.GetCollection<BsonDocument>(c["name"].AsString).AsQueryable();

                var rfidData = new List<RfidData>();
                var wax3Data = new List<Wax3Data>();
                var wax9Data = new List<Wax9Data>();
                var scalesData = new List<ScalesData>();

                foreach (var bsonDocument in collection)
                {
                    if (bsonDocument.Contains("Transponders"))
                    {
                        rfidData.Add(BsonSerializer.Deserialize<RfidData>(bsonDocument));
                    }
                    else if (bsonDocument.Contains("Battery"))
                    {
                        wax3Data.Add(BsonSerializer.Deserialize<Wax3Data>(bsonDocument));
                    }
                    else if (bsonDocument.Contains("GyroX"))
                    {
                        wax9Data.Add(BsonSerializer.Deserialize<Wax9Data>(bsonDocument));
                    }
                    else if (bsonDocument.Contains("Weight"))
                    {
                        scalesData.Add(BsonSerializer.Deserialize<ScalesData>(bsonDocument));
                    }
                }

                Console.WriteLine($"{c["name"].AsString}: Remapping data to new types and inserting into new collection...");
                Console.WriteLine($"{c["name"].AsString}: Rfid: {rfidData.Count}, Wax3: {wax3Data.Count}, Wax9: {wax9Data.Count}, Scales: {scalesData.Count}");

                var newRfidData = rfidData.Select(d => new Service.Models.RfidData
                {
                    DeviceId = d.DeviceId,
                    Timestamp = d.DataTimeStamp,
                    Transponders = d.Transponders
                });

                var newWax3Data = wax3Data.Select(d => new Service.Models.Wax3Data
                {
                    DeviceId = d.DeviceId,
                    Timestamp = d.DataTimeStamp,
                    AccX = d.AccX,
                    AccY = d.AccY,
                    AccZ = d.AccZ
                });

                var newWax9Data = wax9Data.Select(d => new Service.Models.Wax9Data
                {
                    DeviceId = d.DeviceId,
                    Timestamp = d.DataTimeStamp,
                    AccX = d.AccX,
                    AccY = d.AccY,
                    AccZ = d.AccZ,
                    GyroX = d.GyroX,
                    GyroY = d.GyroY,
                    GyroZ = d.GyroZ,
                    MagX = d.MagX,
                    MagY = d.MagY,
                    MagZ = d.MagZ
                });

                var newScalesData = scalesData.Select(d => new Service.Models.ScalesData
                {
                    Timestamp = d.DataTimeStamp,
                    Weight = d.Weight
                });

                var rfidCollection = database.GetCollection<Service.Models.RfidData>(c["name"].AsString + " (clean)");
                var wax3Collection = database.GetCollection<Service.Models.Wax3Data>(c["name"].AsString + " (clean)");
                var wax9Collection = database.GetCollection<Service.Models.Wax9Data>(c["name"].AsString + " (clean)");
                var scalesCollection = database.GetCollection<Service.Models.ScalesData>(c["name"].AsString + " (clean)");

                if (newRfidData.Any()) rfidCollection.InsertMany(newRfidData);
                if (newWax3Data.Any()) wax3Collection.InsertMany(newWax3Data);
                if (newWax9Data.Any()) wax9Collection.InsertMany(newWax9Data);
                if (newScalesData.Any()) scalesCollection.InsertMany(newScalesData);

                Console.WriteLine($"{ c["name"].AsString}: Removing old collection.");

                database.DropCollection(c["name"].AsString);

                Console.WriteLine($"{c["name"].AsString}: Finished!");
            }

            Console.WriteLine("Cleaning complete!");
        }

        private static void CombineDatasets()
        {
            Console.WriteLine("Combining Datasets...");

            MongoConnection.RegisterTypes();

            var mongoClient = new MongoClient("mongodb://192.168.1.101:27017");
            var database = mongoClient.GetDatabase("kitchen");

            database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            var mongoCollections = database.ListCollections();
            mongoCollections.MoveNext();

            var rfidCollection = database.GetCollection<Service.Models.RfidData>("Rfid");
            var wax3Collection = database.GetCollection<Service.Models.Wax3Data>("Wax3");
            var wax9Collection = database.GetCollection<Service.Models.Wax9Data>("Wax9");
            var scalesCollection = database.GetCollection<Service.Models.ScalesData>("Scales");

            foreach (var c in mongoCollections.Current)
            {
                Console.WriteLine($"{c["name"].AsString}: Retrieving old records...");

                var rfidData = new List<Service.Models.RfidData>();
                var wax3Data = new List<Service.Models.Wax3Data>();
                var wax9Data = new List<Service.Models.Wax9Data>();
                var scalesData = new List<Service.Models.ScalesData>();

                var collection = database.GetCollection<BsonDocument>(c["name"].AsString).AsQueryable();

                foreach (var bsonDocument in collection)
                {
                    if (bsonDocument.Contains("Transponders"))
                    {
                        rfidData.Add(BsonSerializer.Deserialize<Service.Models.RfidData>(bsonDocument));
                    }
                    else if (bsonDocument.Contains("GyroX"))
                    {
                        wax9Data.Add(BsonSerializer.Deserialize<Service.Models.Wax9Data>(bsonDocument));
                    }
                    else if (bsonDocument.Contains("AccX"))
                    {
                        wax3Data.Add(BsonSerializer.Deserialize<Service.Models.Wax3Data>(bsonDocument));
                    }
                    else if (bsonDocument.Contains("Weight"))
                    {
                        scalesData.Add(BsonSerializer.Deserialize<Service.Models.ScalesData>(bsonDocument));
                    }
                }

                if (rfidData.Any()) rfidCollection.InsertMany(rfidData);
                if (wax3Data.Any()) wax3Collection.InsertMany(wax3Data);
                if (wax9Data.Any()) wax9Collection.InsertMany(wax9Data);
                if (scalesData.Any()) scalesCollection.InsertMany(scalesData);

                Console.WriteLine($"{c["name"].AsString}: Records combined...");

                database.DropCollection(c["name"].AsString);

                Console.WriteLine($"{c["name"].AsString}: Collection Dropped.");
            }

            Console.WriteLine("Finished Combining Datasets.");
        }

        private static void InsertProductionDataset()
        {
            Console.WriteLine("Inserting Production Data...");

            MongoConnection.RegisterTypes();

            var mongoClient = new MongoClient("mongodb://192.168.1.101:27017");
            var database = mongoClient.GetDatabase("kitchen");
            var primerDatabase = mongoClient.GetDatabase("prismdb");

            database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            var production = new Production();

            Console.WriteLine("Production name: ");
            production.Name = Console.ReadLine();

            Console.WriteLine("Web Media Prefix: ");
            var prefix = Console.ReadLine();

            var takes = new List<Take>();
            var sessions = primerDatabase.GetCollection<dynamic>("sessions").AsQueryable();
            var cameras = new Dictionary<string, Uri>();

            foreach (var session in sessions)
            {
                takes.Add(new Take
                {
                    Name = session.sessionName,
                    Media = ((List<dynamic>)session.recordings).Select(m =>
                    {
                        if (!cameras.ContainsKey(m.name.ToString()))
                        {
                            Console.WriteLine($"Url for camera ({m.name}, {m.mpd}): ");
                            cameras[m.name.ToString()] = new Uri(Console.ReadLine());
                        }
                        var url = new Uri(m.mpd);
                        return new Media
                        {
                            Name = m.name,
                            Url = new Uri(cameras[m.name.ToString()], prefix.TrimEnd('/') + "/" + string.Join("", url.Segments.Take(url.Segments.Length - 1)).TrimStart(Path.AltDirectorySeparatorChar))
                        };
                    }).ToList()
                });
            }

            production.Takes = takes;

            Console.WriteLine("Path to Smappee Appliance Config: ");
            var pathAppliances = Console.ReadLine();

            production.SmappeeConfig = new Dictionary<int, string>();

            using (var applianceReader = new StreamReader(pathAppliances))
            {
                var applianceJson = applianceReader.ReadToEnd();

                dynamic appliances = JsonConvert.DeserializeObject(applianceJson);

                foreach (var item in appliances.appliances)
                {
                    production.SmappeeConfig.Add(int.Parse(item.id.ToString()), item.name.ToString());
                }
            }

            Console.WriteLine("Path to Rfid Config: ");
            var pathRfid = Console.ReadLine();

            production.RfidConfig = new Dictionary<string, string>();

            using (var rfidReader = new StreamReader(pathRfid))
            {
                var rfidJson = rfidReader.ReadToEnd();

                dynamic rfid = JsonConvert.DeserializeObject(rfidJson);

                foreach (var item in rfid)
                {
                    production.RfidConfig.Add(item.transponder.ToString(), item.item.ToString());
                }
            }

            Console.WriteLine("Path to Wax3 Config: ");
            var pathWax3 = Console.ReadLine();

            production.Wax3Config = new Dictionary<int, string>();

            using (var wax3Reader = new StreamReader(pathWax3))
            {
                var wax3Json = wax3Reader.ReadToEnd();

                dynamic wax3 = JsonConvert.DeserializeObject(wax3Json);

                foreach (var item in wax3)
                {
                    production.Wax3Config.Add(int.Parse(item.deviceId.ToString()), item.item.ToString());
                }
            }

            Console.WriteLine("Creating Production...");

            var productions = database.GetCollection<Production>("Productions");

            productions.InsertOne(production);

            Console.WriteLine("Finished Creating Production.");
        }
    }
}
