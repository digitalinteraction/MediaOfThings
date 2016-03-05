using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class Wax9Streamer : ISendRepository<Wax9Data>, IRecieveRepository<Wax9Data>
    {
        private readonly RabbitMqConnection _mqConnection;

        public Wax9Streamer()
        {
            _mqConnection = new RabbitMqConnection("bbckitchen", "wax9");
        }

        public async Task Send(Wax9Data model)
        {
            await _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.DeviceId.ToString());
        }

        public void Subscribe(Action<Wax9Data> handler)
        {
            _mqConnection.Subscribe((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                handler(JsonConvert.DeserializeObject<Wax9Data>(message));
            });
        }

        public void UnSubscribe()
        {
            _mqConnection.UnSubscribe();
        }
    }
}
