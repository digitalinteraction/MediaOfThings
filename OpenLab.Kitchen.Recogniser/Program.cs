using System;
using System.Linq;
using OpenLab.Kitchen.Recogniser.Library;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Repository;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;
using OpenLab.Kitchen.StreamingRepository;

namespace OpenLab.Kitchen.Recogniser
{
    public class Program
    {
        private const string RabbitConnectionString = "amqp://streamer:BlahBlah123@192.168.1.102";
        private const string Exchange = "kitchen";

        private const string MongoDBConnectionString = "mongodb://192.168.1.101:27017/kitchen";

        public static void Main(string[] args)
        {
            Console.WriteLine("Type command to start:");
            Console.WriteLine("    live    - Uses RabbitMQ connection to stream data in and out of recognisers.");
            Console.WriteLine("    replay  - Replays dataset from MongoDB and labels dataset.");

            switch (Console.ReadLine())
            {
                case "live":
                    Live();
                    break;
                case "replay":
                    Replay();
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }

        private static void Live()
        {
            Console.WriteLine("Opening RabbitMQ Connections...");
            IRecieveRepository<Wax3Data> wax3Reciever = new RabbitMqStreamer<Wax3Data>(RabbitConnectionString, Exchange, "wax3");
            ISendRepository<Wax3State> wax3StateSender = new RabbitMqStreamer<Wax3State>(RabbitConnectionString, Exchange, "wax3state");
            IRecieveRepository<RfidData> rfidReciever = new RabbitMqStreamer<RfidData>(RabbitConnectionString, Exchange, "rfid");
            ISendRepository<RfidState> rfidStateSender = new RabbitMqStreamer<RfidState>(RabbitConnectionString, Exchange, "rfidstate");

            Console.WriteLine("Starting Activity Recognisers...");
            IRecogniser<Wax3Data, Wax3State> wax3Recogniser = new Wax3Recogniser(DateTime.Now);
            IRecogniser<RfidData, RfidState> rfidRecogniser = new RfidRecogniser(DateTime.Now);

            Console.WriteLine("Starting Stream Managers...");
            IStreamManager wax3StreamManager = new StreamManager<Wax3Data, Wax3State>(wax3Reciever, wax3StateSender, wax3Recogniser);
            IStreamManager rfidStreamManager = new StreamManager<RfidData, RfidState>(rfidReciever, rfidStateSender, rfidRecogniser);

            wax3StreamManager.Start();
            rfidStreamManager.Start();

            Console.WriteLine("Recognisers Running.");
            Console.WriteLine("Type \"exit\" to terminate process:");

            while ((Console.ReadLine().ToLower()) != "exit") { }

            Console.WriteLine("Terminating Process...");
            wax3StreamManager.Stop();
            rfidStreamManager.Stop();
        }

        private static void Replay()
        {
            Console.WriteLine("Opening MongoDB Connections...");
            IReadOnlyRepository<Wax3Data> wax3Repository = new MongoRepository<Wax3Data>(MongoDBConnectionString, "Wax3");
            IReadWriteRepository<Wax3State> wax3StateRepository = new MongoRepository<Wax3State>(MongoDBConnectionString, "Wax3State");
            IReadOnlyRepository<RfidData> rfidRepository = new MongoRepository<RfidData>(MongoDBConnectionString, "Rfid");
            IReadWriteRepository<RfidState> rfidStateRepository = new MongoRepository<RfidState>(MongoDBConnectionString, "RfidState");

            Console.WriteLine("Reading Replay Dataset...");
            var wax3Data = wax3Repository.GetAll();
            var rfidData = rfidRepository.GetAll();

            Console.WriteLine("Starting Activity Recognisers...");
            IRecogniser<Wax3Data, Wax3State> wax3Recogniser = new Wax3Recogniser(wax3Data.OrderBy(d => d.Timestamp).FirstOrDefault().Timestamp);
            IRecogniser<RfidData, RfidState> rfidRecogniser = new RfidRecogniser(rfidData.OrderBy(d => d.Timestamp).FirstOrDefault().Timestamp);

            Console.WriteLine("Starting Replay Manager...");
            IReplayManager<Wax3State> wax3ReplayManager = new ReplayManager<Wax3Data, Wax3State>(wax3Recogniser, wax3Data);
            IReplayManager<RfidState> rfidReplayManager = new ReplayManager<RfidData, RfidState>(rfidRecogniser, rfidData);

            Console.WriteLine("Processing Datasets...");
            wax3ReplayManager.Process();
            rfidReplayManager.Process();

            Console.WriteLine("Inserting States into MongoDB...");
            foreach (var s in wax3ReplayManager.GetStates())
            {
                wax3StateRepository.Insert(s);
            }

            foreach (var s in rfidReplayManager.GetStates())
            {
                rfidStateRepository.Insert(s);
            }

            Console.WriteLine("Complete.");
        }
    }
}
