using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class ScalesStreamer : ISendRepository<ScalesData>
    {
        private readonly RabbitMqConnection _mqConnection;

        public ScalesStreamer()
        {
            _mqConnection = new RabbitMqConnection("bbckitchen", "scales");
        }

        public void Send(ScalesData model)
        {
            _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.DeviceId);
        }
    }
}
