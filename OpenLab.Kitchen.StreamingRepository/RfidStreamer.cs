using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.StreamingRepository
{
    class RfidStreamer : ISendRepository<RfidData>
    {
        private readonly RabbitMQConnection _mqConnection;

        public RfidStreamer()
        {
            _mqConnection = new RabbitMQConnection("rfid");
        }

        public async Task Send(RfidData model)
        {
            await _mqConnection.SendMessage(model);
        }
    }
}
