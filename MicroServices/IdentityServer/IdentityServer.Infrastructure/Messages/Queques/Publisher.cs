using System.Text;
using RabbitMQ.Client;
using IdentityServer.Domain.Interfaces.Messages;
using Shared.Models;
using Newtonsoft.Json;
using Shared.RabbitMQ;


namespace IdentityServer.Infrastructure.Messages.Queques
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
            _channel.ExchangeDeclare(exchange: "LoggedIn", type: ExchangeType.Fanout);
            _channel.ExchangeDeclare(exchange: "Logout", type: ExchangeType.Fanout);
        }

        public void LoggedInUserPublisher(string id, string userName)
        {
            _channel.QueueDeclare(queue: RabbitMQNamesQueues.CreateProfileUserQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
            arguments: null);

            var props = _channel.CreateBasicProperties();

            props.Persistent = true;

            var claimUser = new ClaimUser { Id = id, UserName = userName };

            var responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(claimUser));

            _channel.BasicPublish(exchange: "LoggedIn",
               routingKey: RabbitMQNamesQueues.CreateProfileUserQueue,
               basicProperties: props,
               body: responseBytes);
        }

        public void LogoutUserPublisher()
        {
            _channel.QueueDeclare(queue: RabbitMQNamesQueues.LogoutProfileUserQueue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var props = _channel.CreateBasicProperties();

            _channel.BasicPublish(exchange: "Logout",
               routingKey: RabbitMQNamesQueues.LogoutProfileUserQueue,
               basicProperties: props,
               body: null);
        }
    }
}