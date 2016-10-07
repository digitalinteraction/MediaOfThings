using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.StreamingRepository
{
    class RfidStreamer : ISendRepository<RfidData>, IRecieveRepository<RfidData>
    {
        private readonly RabbitMqConnection _mqConnection;

        public RfidStreamer()
        {
            _mqConnection = new RabbitMqConnection("kitchen", "rfid");
        }

        public void Send(RfidData model)
        {
            _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.DeviceId);
        }

        public void Subscribe(Action<RfidData> handler)
        {
            _mqConnection.Subscribe((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                handler(JsonConvert.DeserializeObject<RfidData>(message));
            });
        }

        public void UnSubscribe()
        {
            _mqConnection.UnSubscribe();
        }
    }
}
