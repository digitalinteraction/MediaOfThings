using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class Wax3Streamer : ISendRepository<Wax3Data>, IRecieveRepository<Wax3Data>
    {
        private readonly RabbitMqConnection _mqConnection;

        public Wax3Streamer()
        {
            _mqConnection = new RabbitMqConnection("bbckitchen", "wax3");
        }

        public async Task Send(Wax3Data model)
        {
            await _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.DeviceId.ToString());
        }

        public void Subscribe(Action<Wax3Data> handler)
        {
            _mqConnection.Subscribe((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                handler(JsonConvert.DeserializeObject<Wax3Data>(message));
            });
        }

        public void UnSubscribe()
        {
            _mqConnection.UnSubscribe();
        }
    }
}
