﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using CsvHelper;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenLab.Kitchen.StreamingRepository;
using MongoDB.Bson.Serialization;

namespace OpenLab.Kitchen.Capture
{
    class SessionRecorder
    {
        private readonly IMongoClient _mongoClient;
        private readonly Streamer _streamer;

        private ConcurrentBag<BsonDocument> Documents { get; set; } 

        public SessionRecorder()
        {
            _mongoClient = new MongoClient("mongodb://192.168.1.101:27017");
            _streamer = new Streamer();

            Documents = new ConcurrentBag<BsonDocument>();

            _mongoClient.GetDatabase("bbckitchen").RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            Console.WriteLine("RabbitMQ and Mongo connections open.");
        }

        public void StartCapture()
        {
            var database = _mongoClient.GetDatabase("bbckitchen");
            Console.Write("Enter a name for capture session: ");
            var sessionCollection = database.GetCollection<BsonDocument>(Console.ReadLine());

            _streamer.Subscribe((data) =>
            {
                Documents.Add(BsonSerializer.Deserialize<BsonDocument>(data));
            });

            new Timer(async state =>
            {
                if (Documents.Any())
                {
                    var docs = Documents.ToArray();
                    Documents = new ConcurrentBag<BsonDocument>();
                    try
                    {
                        await sessionCollection.InsertManyAsync(docs);
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

            Console.WriteLine("Subscribed to data.");
        }

        public void StopCapture()
        {
            _streamer.UnSubscribe();
        }
    }
}