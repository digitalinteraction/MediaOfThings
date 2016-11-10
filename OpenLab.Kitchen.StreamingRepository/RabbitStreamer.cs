using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.StreamingRepository
{
    public class RabbitStreamer<T> : ISendRepository<T>, IRecieveRepository<T> where T : DataModel
    {
        private readonly RabbitMqConnection _mqConnection;

        public RabbitStreamer(string connectionString, string exchange, string routingKey)
        {
            _mqConnection = new RabbitMqConnection(connectionString, exchange, routingKey);
        }

        public void Send(T model)
        {
            _mqConnection.SendMessage(JsonConvert.SerializeObject(model), model.GetDeviceIdString());
        }

        public void Subscribe(Action<T> handler)
        {
            _mqConnection.Subscribe((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                handler(JsonConvert.DeserializeObject<T>(message));
            });
        }

        public void UnSubscribe()
        {
            _mqConnection.UnSubscribe();
        }
    }
}
