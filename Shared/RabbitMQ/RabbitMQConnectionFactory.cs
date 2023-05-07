using RabbitMQ.Client;

namespace Shared.RabbitMQ
{
    public static class RabbitMQConnectionFactory
    {
        public static ConnectionFactory CreateConnectionFactory()
        {
            return new ConnectionFactory()
            {
                HostName = Environment.GetEnvironmentVariable("RABBIT_HOSTNAME") ?? "localhost",

            };
        }
    }
}