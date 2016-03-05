using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Models.Streaming;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OpenLab.Kitchen.StreamingRepository
{
    class RabbitMqConnection
    {
        private readonly IModel _channel;

        string Exchange { get; }
        string RoutingKey { get; }
        string Consumer { get; set; }

        public RabbitMqConnection(string exchange, string routingKey)
        {
            var factory = new ConnectionFactory {HostName = "ol-kitchen-mq.di-test.com",UserName = "admin", Password = "BlahBlah123"};
            factory.AutomaticRecoveryEnabled = true;
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(exchange, "topic");

            Exchange = exchange;
            RoutingKey = routingKey;
        }

        public async Task SendMessage(string model, string id = null)
        {
            var routingKey = id == null ? RoutingKey : RoutingKey + $".{id}";

            await new Task(
                () =>
                    _channel.BasicPublish(Exchange, routingKey, null,
                        Encoding.UTF8.GetBytes(model)));
        }

        public void Subscribe(EventHandler<BasicDeliverEventArgs> handler)
        {
            var queue = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue, Exchange, RoutingKey);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += handler;
            Consumer = _channel.BasicConsume(queue, true, consumer);
        }

        public void UnSubscribe()
        {
            _channel.BasicCancel(Consumer);
        }
    }
}
