using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Models.Streaming;
using RabbitMQ.Client;

namespace OpenLab.Kitchen.StreamingRepository
{
    class RabbitMQConnection
    {
        private readonly IConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        string Queue { get; }

        public RabbitMQConnection(string queue)
        {
            _factory = new ConnectionFactory {HostName = "ol-kitchen-mq.di-test.com",UserName = "admin", Password = "BlahBlah123"};
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(queue, "topic");

            Queue = queue;
        }

        public async Task SendMessage(StreamingModel model)
        {
            await new Task(
                () =>
                    _channel.BasicPublish(Queue, model.DeviceId.ToString(), null,
                        Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model))));
        }

        public void Subscribe(int id)
        {
            //_channel.QueueBind(Queue, );
        }
    }
}
