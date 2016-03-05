using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class WaterFlowStreamer : ISendRepository<WaterFlow>, IRecieveRepository<WaterFlow>
    {
        private readonly RabbitMqConnection _mqConnection;

        public WaterFlowStreamer()
        {
            _mqConnection = new RabbitMqConnection("bbckitchen", "water");
        }

        public async Task Send(WaterFlow model)
        {
            await _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.DeviceId.ToString());
        }

        public void Subscribe(Action<WaterFlow> handler)
        {
            _mqConnection.Subscribe((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                handler(JsonConvert.DeserializeObject<WaterFlow>(message));
            });
        }

        public void UnSubscribe()
        {
            _mqConnection.UnSubscribe();
        }
    }
}
