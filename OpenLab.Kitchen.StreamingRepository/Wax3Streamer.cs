using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class Wax3Streamer : ISendRepository<Wax3Data>
    {
        private readonly RabbitMQConnection _mqConnection;

        public Wax3Streamer()
        {
            _mqConnection = new RabbitMQConnection("wax3");
        }

        public async Task Send(Wax3Data model)
        {
            await _mqConnection.SendMessage(model);
        }
    }
}
