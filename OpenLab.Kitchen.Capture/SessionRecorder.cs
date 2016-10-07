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

        public SessionRecorder(string sessionName)
        {
            _repository = new GenericRepository("kitchen", sessionName);
            _streamer = new Streamer();

            Console.WriteLine("RabbitMQ and Mongo connections open.");
        }

        public void StartCapture()
        {
            _streamer.Subscribe((data) =>
            {
                _repository.Insert(BsonSerializer.Deserialize<BsonDocument>(data));
            });

            Console.WriteLine("Subscribed to data.");
        }

        public void StopCapture()
        {
            _streamer.UnSubscribe();
        }
    }
}