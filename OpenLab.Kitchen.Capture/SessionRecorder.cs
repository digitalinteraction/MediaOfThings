using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenLab.Kitchen.StreamingRepository;

namespace OpenLab.Kitchen.Capture
{
    class SessionRecorder
    {
        private readonly IMongoClient _mongoClient;
        private readonly Streamer _streamer;

        private ICollection<BsonDocument> Documents { get; set; } 

        public SessionRecorder()
        {
            _mongoClient = new MongoClient("mongodb://OL-Kitchen-Capture:27017");
            _streamer = new Streamer();

            Documents = new List<BsonDocument>();

            Console.WriteLine("RabbitMQ and Mongo connections open.");
        }

        public void StartCapture()
        {
            var database = _mongoClient.GetDatabase("bbckitchen");
            var sessionCollection = database.GetCollection<BsonDocument>(DateTime.Now.Ticks.ToString());

            _streamer.Subscribe(async (data) =>
            {
                Console.WriteLine(data);

                Documents.Add(BsonDocument.Parse(data));

                if (Documents.Count > 100)
                {
                    await sessionCollection.InsertManyAsync(Documents);
                    Documents = new List<BsonDocument>();
                }
            });

            Console.WriteLine("Subscribed to data.");
        }

        public void StopCapture()
        {
            _streamer.UnSubscribe();
        }
    }
}