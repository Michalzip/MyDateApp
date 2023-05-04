using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;
using Shared.RabbitMQ;
using Microsoft.AspNetCore.Identity;
using Shared.Models;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Infrastructure.Messages.Rpc
{
    public class RpcServer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        private readonly IServiceProvider _serviceProvider;

        public RpcServer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var factory = RabbitMQConnectionFactory.CreateConnectionFactory();
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            VipConsumer();
            VipStatusConsumer();
        }

        private async void VipConsumer()
        {
            _channel.QueueDeclare(queue: RabbitMQNamesQueues.VipUserQueue,
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            _channel.BasicQos(
                prefetchSize: 0,
                prefetchCount: 1,
                global: false);

            var vipConsumer = new EventingBasicConsumer(_channel);

            vipConsumer.Received += async (model, e) =>
                                 {
                                     bool response = false;

                                     var body = e.Body.ToArray();
                                     var props = e.BasicProperties;
                                     var replyProps = _channel.CreateBasicProperties();

                                     replyProps.CorrelationId = props.CorrelationId;
                                     try
                                     {
                                         var message = Encoding.UTF8.GetString(body);

                                         var scope = _serviceProvider.CreateScope();
                                         var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                                         var user = await userManager.FindByNameAsync(message);

                                         user.isvVip = true;

                                         var result = await userManager.UpdateAsync(user);

                                         response = result.Succeeded;
                                     }
                                     catch (Exception E)
                                     {
                                         Console.WriteLine(E);
                                         response = false;
                                     }
                                     finally
                                     {
                                         byte[] responseBytes = BitConverter.GetBytes(response);
                                         _channel.BasicPublish(exchange: "",
                                  routingKey: props.ReplyTo,
                                  basicProperties: replyProps,
                                  body: responseBytes);

                                         _channel.BasicAck(deliveryTag: e.DeliveryTag,
                                  multiple: false);
                                     }
                                 };

            _channel.BasicConsume(queue: RabbitMQNamesQueues.VipUserQueue, autoAck: false, consumer: vipConsumer);
        }

        private async void VipStatusConsumer()
        {
            _channel.QueueDeclare(queue: RabbitMQNamesQueues.VipStatusUserQueue,
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            _channel.BasicQos(
                prefetchSize: 0,
                prefetchCount: 1,
                global: false);

            var vipConsumer = new EventingBasicConsumer(_channel);

            vipConsumer.Received += async (model, e) =>
                                 {
                                     bool response = false;

                                     var body = e.Body.ToArray();
                                     var props = e.BasicProperties;
                                     var replyProps = _channel.CreateBasicProperties();

                                     replyProps.CorrelationId = props.CorrelationId;
                                     try
                                     {
                                         var message = Encoding.UTF8.GetString(body);

                                         var scope = _serviceProvider.CreateScope();
                                         var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                                         var user = await userManager.FindByNameAsync(message);

                                         response = user.isvVip;
                                     }
                                     catch (Exception E)
                                     {
                                         Console.WriteLine(E);
                                         response = false;
                                     }
                                     finally
                                     {
                                         byte[] responseBytes = BitConverter.GetBytes(response);
                                         _channel.BasicPublish(exchange: "",
                                  routingKey: props.ReplyTo,
                                  basicProperties: replyProps,
                                  body: responseBytes);

                                         _channel.BasicAck(deliveryTag: e.DeliveryTag,
                                  multiple: false);
                                     }
                                 };

            _channel.BasicConsume(queue: RabbitMQNamesQueues.VipStatusUserQueue, autoAck: false, consumer: vipConsumer);
        }
    }
}