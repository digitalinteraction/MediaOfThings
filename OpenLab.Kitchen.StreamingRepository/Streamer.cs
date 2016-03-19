using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class Streamer
    {
        private readonly RabbitMqConnection _mqConnection;

        public Streamer()
        {
            _mqConnection = new RabbitMqConnection("bbckitchen", "#");
        }

        public void Subscribe(Action<string> handler)
        {
            _mqConnection.Subscribe((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                handler(message);
            });
        }

        public void UnSubscribe()
        {
            _mqConnection.UnSubscribe();
        }
    }
}
