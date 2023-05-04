
using RabbitMQ.Client;
using Microsoft.Extensions.Hosting;
using Shared.RabbitMQ;

namespace IdentityServer.Infrastructure.Messages.Queques
{
    public class Receiver : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public Receiver()
        {
            var factory = RabbitMQConnectionFactory.CreateConnectionFactory();
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
        }
    }
}

