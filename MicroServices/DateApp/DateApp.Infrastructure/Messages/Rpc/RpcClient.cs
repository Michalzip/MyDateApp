using System.Collections.Concurrent;
using System.Text;
using Shared.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using DateApp.Domain.Interfaces.Messages;

namespace DateApp.Infrastructure.Messages.Rpc
{
    public class RpcClient : IDisposable, IRpcClient
    {
        private readonly IConnection connection;
        private readonly IModel _channel;
        private readonly string replyQueueName;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<bool>> callbackMapper = new();
        public RpcClient()
        {
            var factory = RabbitMQConnectionFactory.CreateConnectionFactory();
            connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            replyQueueName = _channel.QueueDeclare().QueueName;
        }

        public Task<bool> CreateVipPublisher(string userName, CancellationToken cancellationToken = default)
        {
            IBasicProperties props = _channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;
            var messageBytes = Encoding.UTF8.GetBytes(userName);
            var tcs = new TaskCompletionSource<bool>();

            var vipConsumer = new EventingBasicConsumer(_channel);
            vipConsumer.Received += (model, ea) =>
            {
                if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    return;
                var body = ea.Body.ToArray();

                var response = BitConverter.ToBoolean(body);

                tcs.TrySetResult(response);
            };

            callbackMapper.TryAdd(correlationId, tcs);

            _channel.BasicPublish(exchange: string.Empty,
                             routingKey: RabbitMQNamesQueues.VipUserQueue,
                             basicProperties: props,
                             body: messageBytes);

            cancellationToken.Register(() => callbackMapper.TryRemove(correlationId, out _));

            _channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: vipConsumer);

            return tcs.Task;
        }

        public Task<bool> VipStatusPublisher(string userName, CancellationToken cancellationToken = default)
        {
            IBasicProperties props = _channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;
            var messageBytes = Encoding.UTF8.GetBytes(userName);
            var tcs = new TaskCompletionSource<bool>();

            var vipConsumer = new EventingBasicConsumer(_channel);
            vipConsumer.Received += (model, ea) =>
            {
                if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    return;
                var body = ea.Body.ToArray();

                var response = BitConverter.ToBoolean(body);

                tcs.TrySetResult(response);
            };

            callbackMapper.TryAdd(correlationId, tcs);

            _channel.BasicPublish(exchange: string.Empty,
                             routingKey: RabbitMQNamesQueues.VipStatusUserQueue,
                             basicProperties: props,
                             body: messageBytes);

            cancellationToken.Register(() => callbackMapper.TryRemove(correlationId, out _));

            _channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: vipConsumer);

            return tcs.Task;
        }

        public void Dispose()
        {
            _channel.Close();
            connection.Close();
        }
    }
}
