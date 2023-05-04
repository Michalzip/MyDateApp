using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Shared.RabbitMQ;
using DateApp.Domain.Interfaces.Messages;

namespace DateApp.Infrastructure.Messages.Queques
{
    public class Publisher : IMessagePublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public Publisher()
        {
            var factory = RabbitMQConnectionFactory.CreateConnectionFactory();
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void CreateVipMessage()
        {
            _channel.QueueDeclare(queue: RabbitMQNamesQueues.VipUserQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var props = _channel.CreateBasicProperties();

            var responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(true));

            _channel.BasicPublish(exchange: "",
               routingKey: RabbitMQNamesQueues.VipUserQueue,
               basicProperties: props,
               body: responseBytes);

            _channel.Close();
            _connection.Close();
        }
    }
}