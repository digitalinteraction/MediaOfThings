using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class Wax3Streamer : ISendRepository<Wax3Data>, IRecieveRepository<Wax3Data>
    {
        private readonly RabbitMqConnection _mqConnection;

        public Wax3Streamer()
        {
            _mqConnection = new RabbitMqConnection("kitchen", "wax3");
        }

        public void Send(Wax3Data model)
        {
            _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.DeviceId);
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
