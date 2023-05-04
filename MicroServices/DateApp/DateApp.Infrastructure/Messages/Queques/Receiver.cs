using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Jwt;
using Newtonsoft.Json;
using Shared.Models;
using Shared.RabbitMQ;

namespace DateApp.Infrastructure.Messages.Queques
{
    public class Receiver : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly ITokenService _tokenService;
        public Receiver(ITokenService tokenService)
        {
            var factory = RabbitMQConnectionFactory.CreateConnectionFactory();
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _tokenService = tokenService;

            _channel.ExchangeDeclare(exchange: "LoggedIn", type: ExchangeType.Fanout);
            _channel.ExchangeDeclare(exchange: "Logout", type: ExchangeType.Fanout);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            LoggedInConsumer();
            LogoutProfileConsumer();
        }

        public void LoggedInConsumer()
        {
            _channel.QueueDeclare(queue: RabbitMQNamesQueues.CreateProfileUserQueue,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            _channel.QueueBind(queue: RabbitMQNamesQueues.CreateProfileUserQueue,
                            exchange: "LoggedIn",
                            routingKey: RabbitMQNamesQueues.CreateProfileUserQueue);

            var profileConsumer = new EventingBasicConsumer(_channel);

            profileConsumer.Received += (model, ea) =>
                      {
                          var body = ea.Body.ToArray();

                          var response = Encoding.UTF8.GetString(body);

                          var claimData = JsonConvert.DeserializeObject<ClaimUser>(response);

                          _tokenService.CreateToken(claimData.Id, claimData.UserName);
                      };

            _channel.BasicConsume(queue: RabbitMQNamesQueues.CreateProfileUserQueue,
                autoAck: false,
                consumer: profileConsumer);
        }

        public void LogoutProfileConsumer()
        {
            _channel.QueueDeclare(queue: RabbitMQNamesQueues.LogoutProfileUserQueue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            _channel.QueueBind(queue: RabbitMQNamesQueues.LogoutProfileUserQueue,
                           exchange: "Logout",
                           routingKey: RabbitMQNamesQueues.LogoutProfileUserQueue);

            var profileLogoutConsumer = new EventingBasicConsumer(_channel);

            profileLogoutConsumer.Received += (model, ea) =>
            {
                _tokenService.RemoveToken();
                //delete message ququqe from CreateProfileUserQueue and LogoutProfileConsumer
                _channel.BasicAck(deliveryTag: 2, multiple: true);
            };

            _channel.BasicConsume(queue: RabbitMQNamesQueues.LogoutProfileUserQueue,
                autoAck: false,
                consumer: profileLogoutConsumer);
        }
    }
}


