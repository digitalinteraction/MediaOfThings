using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class Wax9Streamer : ISendRepository<Wax9Data>
    {
        private readonly RabbitMQConnection _mqConnection;

        public Wax9Streamer()
        {
            _mqConnection = new RabbitMQConnection("wax9");
        }

        public async Task Send(Wax9Data model)
        {
            await _mqConnection.SendMessage(model);
        }
    }
}
