using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class MarkerStreamer : ISendRepository<Marker>, IRecieveRepository<Marker>
    {
        private readonly RabbitMqConnection _mqConnection;

        public MarkerStreamer()
        {
            _mqConnection = new RabbitMqConnection("bbckitchen", "marker");
        }

        public async Task Send(Marker model)
        {
            await _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.DeviceId.ToString());
        }

        public void Subscribe(Action<Marker> handler)
        {
            _mqConnection.Subscribe((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                handler(JsonConvert.DeserializeObject<Marker>(message));
            });
        }

        public void UnSubscribe()
        {
            _mqConnection.UnSubscribe();
        }
    }
}
