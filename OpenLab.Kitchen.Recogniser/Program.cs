using System;
using System.Linq;
using System.Threading;
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
        private const int TickPeriod = 100;
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

        private static void Live(Production production)
        {
            Console.WriteLine("Opening RabbitMQ Connections...");
            IRecieveRepository<Wax3Data> wax3Reciever = new RabbitMqStreamer<Wax3Data>(RabbitConnectionString, Exchange);
            ISendRepository<Wax3State> wax3StateSender = new RabbitMqStreamer<Wax3State>(RabbitConnectionString, Exchange);
            IRecieveRepository<RfidData> rfidReciever = new RabbitMqStreamer<RfidData>(RabbitConnectionString, Exchange);
            ISendRepository<RfidState> rfidStateSender = new RabbitMqStreamer<RfidState>(RabbitConnectionString, Exchange);
            IRecieveRepository<Wax3State> wax3StateReciever = new RabbitMqStreamer<Wax3State>(RabbitConnectionString, Exchange);
            IRecieveRepository<RfidState> rfidStateReciever = new RabbitMqStreamer<RfidState>(RabbitConnectionString, Exchange);
            IRecieveRepository<ApplianceEvent> appEventReciever = new RabbitMqStreamer<ApplianceEvent>(RabbitConnectionString, Exchange);
            ISendRepository<AoiState> aoiStateSender = new RabbitMqStreamer<AoiState>(RabbitConnectionString, Exchange);

            Console.WriteLine("Starting Activity Recognisers...");
            IRecogniser<Wax3Data, Wax3State> wax3Recogniser = new Wax3Recogniser(DateTime.Now);
            IRecogniser<RfidData, RfidState> rfidRecogniser = new RfidRecogniser(DateTime.Now);

            Console.WriteLine("Starting Area of Interest Classifier...");
            var aoiClassifier = new AoiClassifier(DateTime.Now, production); // TODO: Needs Production Config to run in Live...

            Console.WriteLine("Starting Stream Managers...");
            IStreamManager wax3StreamManager = new StreamManager<Wax3Data, Wax3State>(wax3Reciever, wax3StateSender, wax3Recogniser);
            IStreamManager rfidStreamManager = new StreamManager<RfidData, RfidState>(rfidReciever, rfidStateSender, rfidRecogniser);
            IStreamManager aoiWax3StreamManager = new StreamManager<Wax3State, AoiState>(wax3StateReciever, aoiStateSender, aoiClassifier);
            IStreamManager aoiRfidStreamManager = new StreamManager<RfidState, AoiState>(rfidStateReciever, aoiStateSender, aoiClassifier);
            IStreamManager aoiAppStreamManager = new StreamManager<ApplianceEvent, AoiState>(appEventReciever, aoiStateSender, aoiClassifier);

            wax3StreamManager.Start();
            rfidStreamManager.Start();

            Console.WriteLine("Recognisers Running.");

            aoiWax3StreamManager.Start();
            aoiRfidStreamManager.Start();
            aoiAppStreamManager.Start();

            Console.WriteLine("Area of Interest Classifier runnning.");

            var timer = new Timer((state) =>
            {
                wax3Recogniser.UpdateClock(DateTime.Now);
                rfidRecogniser.UpdateClock(DateTime.Now);
                aoiClassifier.UpdateClock(DateTime.Now);
            }, null, TickPeriod, Timeout.Infinite);

            Console.WriteLine("Type \"exit\" to terminate process:");

            while ((Console.ReadLine().ToLower()) != "exit") { }

            Console.WriteLine("Terminating Process...");
            timer.Dispose();
            wax3StreamManager.Stop();
            rfidStreamManager.Stop();
            aoiWax3StreamManager.Stop();
            aoiRfidStreamManager.Stop();
            aoiAppStreamManager.Stop();
        }

        private static void Replay(Production production)
        {
            Console.WriteLine("Opening MongoDB Connections...");
            IReadOnlyRepository<Wax3Data> wax3Repository = new MongoRepository<Wax3Data>(MongoDBConnectionString);
            IReadWriteRepository<Wax3State> wax3StateRepository = new MongoRepository<Wax3State>(MongoDBConnectionString);
            IReadOnlyRepository<RfidData> rfidRepository = new MongoRepository<RfidData>(MongoDBConnectionString);
            IReadWriteRepository<RfidState> rfidStateRepository = new MongoRepository<RfidState>(MongoDBConnectionString);
            IReadWriteRepository<AoiState> aoiStateRepository = new MongoRepository<AoiState>(MongoDBConnectionString);

            Console.WriteLine("Reading Replay Dataset...");
            var wax3Data = wax3Repository.GetAll().OrderBy(d => d.Timestamp);
            var rfidData = rfidRepository.GetAll().OrderBy(d => d.Timestamp);

            Console.WriteLine("Starting Activity Recognisers...");
            IRecogniser<Wax3Data, Wax3State> wax3Recogniser = new Wax3Recogniser(wax3Data.FirstOrDefault().Timestamp);
            IRecogniser<RfidData, RfidState> rfidRecogniser = new RfidRecogniser(rfidData.OrderBy(d => d.Timestamp).FirstOrDefault().Timestamp);

            Console.WriteLine("Starting Replay Managers...");
            IReplayManager<Wax3State> wax3ReplayManager = new ReplayManager<Wax3Data, Wax3State>(wax3Recogniser, wax3Data);
            IReplayManager<RfidState> rfidReplayManager = new ReplayManager<RfidData, RfidState>(rfidRecogniser, rfidData);

            Console.WriteLine("Processing Datasets...");
            wax3ReplayManager.Process();
            rfidReplayManager.Process();

            var wax3States = wax3ReplayManager.GetStates().OrderBy(d => d.Timestamp);
            var rfidStates = rfidReplayManager.GetStates().OrderBy(d => d.Timestamp);

            Console.WriteLine("Inserting States into MongoDB...");
            wax3StateRepository.InsertMany(wax3States);
            rfidStateRepository.InsertMany(rfidStates);

            Console.WriteLine("Starting Area of Interest Classifier...");
            var aoiClassifier = new AoiClassifier(DateTime.Now, production); // TODO: Needs Production Config to run in Live...

            Console.WriteLine("Starting Replay Managers...");
            IReplayManager<AoiState> aoiReplayManager = new ClassifierReplayManager(aoiClassifier, wax3States, rfidStates);

            Console.WriteLine("Complete.");
        }
    }
}
