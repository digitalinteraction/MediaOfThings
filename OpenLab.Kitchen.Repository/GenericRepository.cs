using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using System.Threading;

namespace OpenLab.Kitchen.Repository
{
    public class GenericRepository : IReadWriteRepository<BsonDocument>
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<BsonDocument> _mongoCollection;

        private ConcurrentBag<BsonDocument> Cache { get; set; }

        public GenericRepository(string dbName, string collectionName)
        {
            _mongoClient = new MongoClient("mongodb://OL-Kitchen-Capture:27017");

            _mongoClient.GetDatabase("bbckitchen").RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            _mongoCollection = _mongoClient.GetDatabase(dbName).GetCollection<BsonDocument>(collectionName);
        }

        private void InsertThread()
        {
            new Timer(async state =>
            {
                if (Cache.Any())
                {
                    var docs = Cache.ToArray();
                    Cache = new ConcurrentBag<BsonDocument>();
                    try
                    {
                        await _mongoCollection.InsertManyAsync(docs);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unable to write documents: {e}\nDocuments saved to csv.");

                        Directory.CreateDirectory("faileduploads");
                        using (var csv = new StreamWriter($"faileduploads/{Guid.NewGuid()}.csv"))
                        {
                            try
                            {
                                csv.Write(string.Join("\n", docs.Select(d => d.ToJson())));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Failed to write CSV records: {ex}");
                            }
                        }
                    }
                }
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        public void Insert(BsonDocument model)
        {
            Cache.Add(BsonSerializer.Deserialize<BsonDocument>(model));
        }

        public void Update(BsonDocument model)
        {
            _mongoCollection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", model["_id"]), model);
        }

        public void Delete(BsonDocument model)
        {
            _mongoCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", model["_id"]));
        }

        public BsonDocument GetById(ObjectId id)
        {
            return _mongoCollection.FindSync(Builders<BsonDocument>.Filter.Eq("_id", id)).Single();
        }

        public IQueryable<BsonDocument> GetAll()
        {
            _mongoCollection.
        }
    }
}
