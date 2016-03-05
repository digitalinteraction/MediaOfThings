using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using OpenLab.Kitchen.StreamingRepository;

namespace OpenLab.Kitchen.Capture
{
    class SessionRecorder
    {
        private readonly DocumentClient _documentClient;
        private readonly Wax3Streamer _wax3Streamer;
        private readonly Wax9Streamer _wax9Streamer;
        private readonly RfidStreamer _rfidStreamer;

        public SessionRecorder()
        {
            _documentClient = new DocumentClient(new Uri(ConfigurationManager.AppSettings["EndPointUrl"]), ConfigurationManager.AppSettings["AuthorizationKey"]);
            _wax3Streamer = new Wax3Streamer();
            _wax9Streamer = new Wax9Streamer();
            _rfidStreamer = new RfidStreamer();
        }

        public async void StartCapture()
        {
            var sessionCollection = await _documentClient.CreateDocumentCollectionAsync(UriFactory.CreateDatabaseUri(ConfigurationManager.AppSettings["DatabaseId"]), new DocumentCollection { Id = DateTime.Now.Ticks.ToString() });

            _wax3Streamer.Subscribe((data) =>
            {
                _documentClient.CreateDocumentAsync(
                    UriFactory.CreateDocumentCollectionUri(ConfigurationManager.AppSettings["DatabaseId"],
                        sessionCollection.Resource.Id), data);
            });

            _wax9Streamer.Subscribe((data) =>
            {
                _documentClient.CreateDocumentAsync(
                    UriFactory.CreateDocumentCollectionUri(ConfigurationManager.AppSettings["DatabaseId"],
                        sessionCollection.Resource.Id), data);
            });

            _rfidStreamer.Subscribe((data) =>
            {
                _documentClient.CreateDocumentAsync(
                    UriFactory.CreateDocumentCollectionUri(ConfigurationManager.AppSettings["DatabaseId"],
                        sessionCollection.Resource.Id), data);
            });
        }

        public void StopCapture()
        {
            _wax3Streamer.UnSubscribe();
            _wax9Streamer.UnSubscribe();
            _rfidStreamer.UnSubscribe();
        }
    }
}