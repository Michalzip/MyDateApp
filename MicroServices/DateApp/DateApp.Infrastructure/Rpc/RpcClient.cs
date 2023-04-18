
using System.Collections.Concurrent;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Models;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;

namespace DateApp.Infrastructure.Rpc
{
    public class RpcClient : IDisposable
    {

        // private readonly IConnection _connection;
        // private readonly IModel _channel;
        // private readonly string _replyQueueName;
        // private readonly EventingBasicConsumer _consumer;
        // private readonly IBasicProperties _selfProps;
        // private readonly string _correlationId;
        // private readonly TaskCompletionSource<ApplicationUser> tcs;
        // private readonly BlockingCollection<ApplicationUser> _respQueue = new BlockingCollection<ApplicationUser>();
        // private readonly ConcurrentDictionary<string, TaskCompletionSource<ApplicationUser>> callbackMapper = new();

        // public RpcClient()
        // {
        //     var factory = new ConnectionFactory { HostName = "localhost" };



        //     _connection = factory.CreateConnection();
        //     _channel = _connection.CreateModel();
        //     _replyQueueName = _channel.QueueDeclare().QueueName;

        //     _correlationId = Guid.NewGuid().ToString();

        //     _selfProps = _channel.CreateBasicProperties();
        //     _selfProps.CorrelationId = _correlationId;
        //     _selfProps.ReplyTo = _replyQueueName;

        //     _consumer = new EventingBasicConsumer(_channel);
        //     _consumer.Received += ConsumerReceived;
        // }

        // private void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        // {



        //     var body = e.Body.ToArray();
        //     var response = Encoding.UTF8.GetString(body);
        //     var userData = JsonConvert.DeserializeObject<ApplicationUser>(response);

        //     tcs.TrySetResult(userData);

        //     // if (e.BasicProperties.CorrelationId == _correlationId)
        //     //     _respQueue.Add(response);
        // }
        // public ApplicationUser Call(string message)
        // {
        //     var messageBytes = Encoding.UTF8.GetBytes(message);
        //     _channel.BasicPublish(
        //         exchange: "",
        //         routingKey: "rpc_queue",
        //         basicProperties: _selfProps,
        //         body: messageBytes);

        //     _channel.BasicConsume(
        //         consumer: _consumer,
        //         queue: _replyQueueName,
        //         autoAck: true);

        //     return _respQueue.Take();
        // }

        // public void Dispose()
        // {
        //     _consumer.Received -= ConsumerReceived;
        //     _channel.Close();
        //     _connection.Close();
        // }


        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly string replyQueueName;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> callbackMapper = new();
        public RpcClient()
        {

            var factory = new ConnectionFactory { HostName = "localhost" };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            replyQueueName = channel.QueueDeclare().QueueName;

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    return;
                var body = ea.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);
                // var userData = JsonConvert.DeserializeObject<ApplicationUser>(response);

                tcs.TrySetResult(response);
            };

            channel.BasicConsume(consumer: consumer,
                                 queue: replyQueueName,
                                 autoAck: true);
        }


        public Task<string> CallAsync(string message, CancellationToken cancellationToken = default)
        {

            Console.WriteLine("Use CallAsync");

            IBasicProperties props = channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var tcs = new TaskCompletionSource<string>();
            // var tcs = new TaskCompletionSource<ApplicationUser>();
            callbackMapper.TryAdd(correlationId, tcs);



            channel.BasicPublish(exchange: string.Empty,
                             routingKey: "rpc_queue",
                             basicProperties: props,
                             body: messageBytes);

            cancellationToken.Register(() => callbackMapper.TryRemove(correlationId, out _));

            Console.WriteLine(tcs);

            // channel.Close();
            // connection.Close();

            return tcs.Task;


        }

        public void Dispose()
        {
            channel.Close();
            connection.Close();
        }





        // public void Dispose()
        // {
        //     connection.Close();
        // }
    }
}


