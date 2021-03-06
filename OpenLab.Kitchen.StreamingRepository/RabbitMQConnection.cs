﻿using System;
using System.Text;
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

        public RabbitMqConnection(string connectionString, string exchange, string routingKey)
        {
            var factory = new ConnectionFactory { Uri = connectionString };
            factory.AutomaticRecoveryEnabled = true;
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ContinuationTimeout = TimeSpan.FromMilliseconds(100);

            _channel.ExchangeDeclare(exchange, "topic");

            Exchange = exchange;
            RoutingKey = routingKey;
        }

        public void SendMessage(string model, string id = null)
        {
            var routingKey = id == null ? RoutingKey : RoutingKey + $".{id}";

            _channel.BasicPublish(Exchange, routingKey, null, Encoding.UTF8.GetBytes(model));
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
