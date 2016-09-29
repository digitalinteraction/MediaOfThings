using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using CsvHelper;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenLab.Kitchen.Repository;
using OpenLab.Kitchen.StreamingRepository;
using MongoDB.Bson.Serialization;

namespace OpenLab.Kitchen.Capture
{
    class SessionRecorder
    {
        private readonly GenericRepository _repository;
        private readonly Streamer _streamer;

        private ConcurrentBag<BsonDocument> Documents { get; set; } 

        public SessionRecorder(string sessionName)
        {
            _repository = new GenericRepository("bbckitchen", sessionName);
            _streamer = new Streamer();

            Documents = new ConcurrentBag<BsonDocument>();

            

            Console.WriteLine("RabbitMQ and Mongo connections open.");
        }

        public void StartCapture()
        {
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