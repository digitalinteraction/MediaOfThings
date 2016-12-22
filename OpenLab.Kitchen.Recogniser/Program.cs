using System;
using System.Linq;
using System.Threading;
using OpenLab.Kitchen.Recogniser.Library;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Recogniser.Library.Validation;
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
            Console.WriteLine("Reading Production Configuration...");

            IReadOnlyRepository<Production> productionRepository = new MongoRepository<Production>(MongoDBConnectionString);
            var productions = productionRepository.GetAll().ToArray();

            Console.WriteLine("Select Production Configuration:");

            for (var i = 0; i < productions.Length; i++)
            {
                Console.WriteLine($"    [{i}] - {productions[i].Name}");
            }

            var index = int.Parse(Console.ReadLine());
            var production = productions[index];

            Console.WriteLine("Type command to start:");
            Console.WriteLine("    live     - Uses RabbitMQ connection to stream data in and out of recognisers.");
            Console.WriteLine("    replay   - Replays dataset from MongoDB and labels dataset.");
            Console.WriteLine("    validate - Validates labeled dataset.");

            switch (Console.ReadLine())
            {
                case "live":
                    Live(production);
                    break;
                case "replay":
                    Replay(production);
                    break;
                case "validate":
                    ValidateAoi(production);
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }

            Console.ReadLine();
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
            IRecogniser<Wax3Data, Wax3State> wax3Recogniser = new Wax3Recogniser();
            IRecogniser<RfidData, RfidState> rfidRecogniser = new RfidRecogniser();

            Console.WriteLine("Starting Area of Interest Classifier...");
            var aoiClassifier = new AoiClassifier(production); // TODO: Needs Production Config to run in Live...

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
            IReadOnlyRepository<ApplianceEvent> appEventRepository = new MongoRepository<ApplianceEvent>(MongoDBConnectionString);
            IReadWriteRepository<AoiState> aoiStateRepository = new MongoRepository<AoiState>(MongoDBConnectionString);

            Console.WriteLine("Reading Replay Dataset...");
            var wax3Data = wax3Repository.GetAll().ToList().Where(d => d.Timestamp.Date == production.Takes.First().Media.First().StartTime.Date).OrderBy(d => d.Timestamp).AsQueryable();
            var rfidData = rfidRepository.GetAll().ToList().Where(d => d.Timestamp.Date == production.Takes.First().Media.First().StartTime.Date).OrderBy(d => d.Timestamp).AsQueryable();

            if (!wax3Data.Any() || !rfidData.Any())
            {
                Console.WriteLine("No Data to Replay. Exiting.");
                return;
            } 

            Console.WriteLine("Starting Activity Recognisers...");
            IRecogniser<Wax3Data, Wax3State> wax3Recogniser = new Wax3Recogniser();
            IRecogniser<RfidData, RfidState> rfidRecogniser = new RfidRecogniser();

            Console.WriteLine("    Starting Replay Managers...");
            IReplayManager<Wax3State> wax3ReplayManager = new ReplayManager<Wax3Data, Wax3State>(wax3Recogniser, wax3Data);
            IReplayManager<RfidState> rfidReplayManager = new ReplayManager<RfidData, RfidState>(rfidRecogniser, rfidData);

            Console.WriteLine("    Processing Datasets...");
            wax3ReplayManager.Process();
            rfidReplayManager.Process();

            var wax3States = wax3ReplayManager.GetStates().AsQueryable();
            var rfidStates = rfidReplayManager.GetStates().AsQueryable();

            Console.WriteLine("    Inserting States into MongoDB...");
            wax3StateRepository.InsertMany(wax3States);
            rfidStateRepository.InsertMany(rfidStates);

            Console.WriteLine("Starting Area of Interest Classifier...");
            var aoiClassifier = new AoiClassifier(production);

            Console.WriteLine("    Starting Replay Managers...");
            IReplayManager<AoiState> aoiReplayManager = new AoiReplayManager(aoiClassifier, wax3States, rfidStates, appEventRepository.GetAll());
            
            Console.WriteLine("    Processing Datasets...");
            aoiReplayManager.Process();

            var aoiStates = aoiReplayManager.GetStates();

            Console.WriteLine("    Inserting States into MongoDB...");
            aoiStateRepository.InsertMany(aoiStates);

            Console.WriteLine("Complete.");
        }

        private static void ValidateAoi(Production production)
        {
            Console.WriteLine("Opening MongoDB Connections...");
            IReadOnlyRepository<AoiState> aoiRepository = new MongoRepository<AoiState>(MongoDBConnectionString);
            IReadOnlyRepository<GTLocation> gtLocationRepository = new MongoRepository<GTLocation>(MongoDBConnectionString);

            Console.WriteLine("Starting Aoi Validator...");
            var aoiValidator = new AoiValidator(production, aoiRepository.GetAll().ToList().AsQueryable(), gtLocationRepository.GetAll().ToList().AsQueryable());

            Console.WriteLine("    Running Area Validation...");
            var areaResult = aoiValidator.ValidateAllAreas(1.0);

            foreach (var r in areaResult)
            {
                Console.WriteLine($"        {r.Key}:");
                Console.WriteLine($"            TP: {r.Value.TruePositive}");
                Console.WriteLine($"            TN: {r.Value.TrueNegative}");
                Console.WriteLine($"            FP: {r.Value.FalsePositive}");
                Console.WriteLine($"            FN: {r.Value.FalseNegative}");
            }

            Console.WriteLine("    Running Group Validation...");
            var groupResult = aoiValidator.ValidateGroups(1.0);

            Console.WriteLine("        Group Validation Matrix:");
            for (var i = 0; i < groupResult.CM.GetLength(0); i++)
            {
                Console.Write("      ");
                for (var j = 0; j < groupResult.CM.GetLength(1); j++)
                {
                    Console.Write($"  {groupResult.CM[i,j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"        Unknown: {groupResult.Unknown}");
        }
    }
}
