using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using OpenLab.Kitchen.Repository;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.MongoCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type command to start:");
            Console.WriteLine("    clean     - Cleans Old Mongo records and remaps to new models.");
            Console.WriteLine("    configure - Configures datasets.");
            Console.WriteLine("    combine   - Combines all datasets into sensor collections.");
            var com = Console.ReadLine();

            switch (com)
            {
                case "clean":
                    CleanMongo();
                    break;
                case "configure":
                    ConfigureDatasets();
                    break;
                case "combine":
                    CombineDatasets();
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
                    TimeStamp = d.DataTimeStamp,
                    Transponders = d.Transponders
                });

                var newWax3Data = wax3Data.Select(d => new Service.Models.Wax3Data
                {
                    DeviceId = d.DeviceId,
                    TimeStamp = d.DataTimeStamp,
                    AccX = d.AccX,
                    AccY = d.AccY,
                    AccZ = d.AccZ
                });

                var newWax9Data = wax9Data.Select(d => new Service.Models.Wax9Data
                {
                    DeviceId = d.DeviceId,
                    TimeStamp = d.DataTimeStamp,
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
                    DeviceId = d.DeviceId,
                    TimeStamp = d.DataTimeStamp,
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

        private static void ConfigureDatasets()
        {
            Console.WriteLine("Configuring Datasets...");

            MongoConnection.RegisterTypes();

            var mongoClient = new MongoClient("mongodb://192.168.1.101:27017");
            var database = mongoClient.GetDatabase("kitchen");

            database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            var collection = database.GetCollection<Service.Models.Dataset>("Datasets");

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Chocpots Day 1 Take 1",
                StartTime = DateTime.Parse("2016-04-06 13:56:42.696Z"),
                EndTime = DateTime.Parse("2016-04-06 14:07:52.485Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Chocpots Day 1 Take 2",
                StartTime = DateTime.Parse("2016-04-06 14:33:28.304Z"),
                EndTime = DateTime.Parse("2016-04-06 14:46:36.488Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Chocpots Day 1 Take 3",
                StartTime = DateTime.Parse("2016-04-06 14:59:03.944Z"),
                EndTime = DateTime.Parse("2016-04-06 15:05:41.419Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Chocpots Day 2 Take 1",
                StartTime = DateTime.Parse("2016-04-07 12:53:42.732Z"),
                EndTime = DateTime.Parse("2016-04-07 13:06:42.043Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Chocpots Day 2 Take 2",
                StartTime = DateTime.Parse("2016-04-07 13:14:14.886Z"),
                EndTime = DateTime.Parse("2016-04-07 13:56:04.459Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Chocpots Day 2 Take 3",
                StartTime = DateTime.Parse("2016-04-07 13:56:47.381Z"),
                EndTime = DateTime.Parse("2016-04-07 13:58:06.241Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Final Shots Day 2 Take 1",
                StartTime = DateTime.Parse("2016-04-07 18:12:23.661Z"),
                EndTime = DateTime.Parse("2016-04-07 18:24:02.065Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Fish and Sides Day 1 Take 1",
                StartTime = DateTime.Parse("2016-04-06 15:51:02.755Z"),
                EndTime = DateTime.Parse("2016-04-06 16:07:37.489Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Fish and Sides Day 1 Take 2",
                StartTime = DateTime.Parse("2016-04-06 16:07:50.505Z"),
                EndTime = DateTime.Parse("2016-04-06 16:29:44.051Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Fish and Sides Day 1 Take 3",
                StartTime = DateTime.Parse("2016-04-06 16:39:12.059Z"),
                EndTime = DateTime.Parse("2016-04-06 16:41:05.131Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Fish and Sides Day 1 Take 3",
                StartTime = DateTime.Parse("2016-04-06 16:46:11.840Z"),
                EndTime = DateTime.Parse("2016-04-06 16:50:09.889Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Ingredients Close-up Day 2 Take 1",
                StartTime = DateTime.Parse("2016-04-07 11:48:30.129Z"),
                EndTime = DateTime.Parse("2016-04-07 11:57:14.488Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Ingredients Close-up Day 2 Take 2",
                StartTime = DateTime.Parse("2016-04-07 12:02:57.097Z"),
                EndTime = DateTime.Parse("2016-04-07 12:40:41.655Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Ingredients Close-up Day 2 Take 3",
                StartTime = DateTime.Parse("2016-04-07 14:10:43.321Z"),
                EndTime = DateTime.Parse("2016-04-07 14:36:42.834Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Introductions Day 1 Take 1",
                StartTime = DateTime.Parse("2016-04-06 13:09:38.509Z"),
                EndTime = DateTime.Parse("2016-04-06 13:13:33.483Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Introductions Day 1 Take 2",
                StartTime = DateTime.Parse("2016-04-06 13:14:36.681Z"),
                EndTime = DateTime.Parse("2016-04-06 13:16:39.558Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Introductions Day 1 Take 3",
                StartTime = DateTime.Parse("2016-04-06 13:20:28.415Z"),
                EndTime = DateTime.Parse("2016-04-06 13:22:36.125Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Introductions Day 2 Take 1",
                StartTime = DateTime.Parse("2016-04-07 09:50:37.012Z"),
                EndTime = DateTime.Parse("2016-04-07 10:04:21.714Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Introductions Day 2 Take 2",
                StartTime = DateTime.Parse("2016-04-07 10:13:19.604Z"),
                EndTime = DateTime.Parse("2016-04-07 11:47:32.114Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Kale Day 2 Take 1",
                StartTime = DateTime.Parse("2016-04-07 15:17:58.410Z"),
                EndTime = DateTime.Parse("2016-04-07 16:08:37.582Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Mains Day 2 Take 1",
                StartTime = DateTime.Parse("2016-04-07 14:36:50.959Z"),
                EndTime = DateTime.Parse("2016-04-07 15:17:50.629Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Mains Day 2 Take 2",
                StartTime = DateTime.Parse("2016-04-07 16:08:59.343Z"),
                EndTime = DateTime.Parse("2016-04-07 18:11:57.179Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Test Run 1",
                StartTime = DateTime.Parse("2016-04-06 09:45:38.267Z"),
                EndTime = DateTime.Parse("2016-04-06 10:00:04.048Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Test Run 2",
                StartTime = DateTime.Parse("2016-04-06 15:23:15.787Z"),
                EndTime = DateTime.Parse("2016-04-06 15:23:29.162Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Test Run 3",
                StartTime = DateTime.Parse("2016-04-06 15:25:46.225Z"),
                EndTime = DateTime.Parse("2016-04-06 15:26:19.944Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Test Run 4",
                StartTime = DateTime.Parse("2016-04-06 11:40:13.074Z"),
                EndTime = DateTime.Parse("2016-04-06 11:53:22.293Z")
            });

            collection.InsertOne(new Dataset
            {
                Name = "BBC R&D Shoot: Test Run 5",
                StartTime = DateTime.Parse("2016-04-07 08:59:13.293Z"),
                EndTime = DateTime.Parse("2016-04-07 08:59:37.652Z")
            });

            Console.WriteLine("Datasets Configured.");
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
    }
}
