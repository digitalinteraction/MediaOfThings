using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class Wax9Streamer : ISendRepository<Wax9Data>, IRecieveRepository<Wax9Data>
    {
        private readonly RabbitMqConnection _mqConnection;

        public Wax9Streamer()
        {
            _mqConnection = new RabbitMqConnection("kitchen", "wax9");
        }

        public void Send(Wax9Data model)
        {
            _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.DeviceId);
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
