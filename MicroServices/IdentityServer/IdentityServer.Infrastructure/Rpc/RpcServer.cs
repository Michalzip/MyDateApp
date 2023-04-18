using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Models;
using Shared.Abstraction.Extensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer.Infrastructure.Rpc
{
    // public class RpcServer : BackgroundService
    // {

    //     private readonly IConnection _connection;
    //     private readonly IModel _channel;
    //     private readonly EventingBasicConsumer _consumer;




    //     private readonly IServiceProvider _serviceProvider;



    //     public RpcServer(IServiceProvider serviceProvider)
    //     {

    //         _serviceProvider = serviceProvider;

    //         var factory = new ConnectionFactory { HostName = "localhost" };

    //         _connection = factory.CreateConnection();
    //         _channel = _connection.CreateModel();
    //         _consumer = new EventingBasicConsumer(_channel);
    //     }

    //     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //     {
    //         Start();

    //         //return Task.CompletedTask;
    //     }

    //     public void Start()
    //     {
    //         _channel.QueueDeclare(queue: "rpc_queue",
    //             durable: false,
    //             exclusive: false,
    //             autoDelete: false,
    //             arguments: null);

    //         _channel.BasicQos(
    //             prefetchSize: 0,
    //             prefetchCount: 1,
    //             global: false);

    //         _channel.BasicConsume(queue: "rpc_queue",
    //             autoAck: false,
    //             consumer: _consumer);


    //         _consumer.Received += ConsumerReceived;
    //     }



    //     private void ConsumerReceived(object sender, BasicDeliverEventArgs e)
    //     {

    //         var response = "";

    //         var body = e.Body.ToArray();
    //         var props = e.BasicProperties;
    //         var replyProps = _channel.CreateBasicProperties();
    //         replyProps.CorrelationId = props.CorrelationId;




    //         try
    //         {
    //             var message = Encoding.UTF8.GetString(body);



    //             var w = new ApplicationUser { UserName = "Adam" };


    //             //var httpContextAccessor = _serviceProvider.GetRequiredService<MyCustomClass>();

    //             //httpContextAccessor.DoSomething();

    //             //var sourceUserName = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);


    //             //Console.WriteLine("Name: ");




    //             response = JsonConvert.SerializeObject(w);


    //         }
    //         catch (Exception ex)
    //         {

    //             response = "";
    //         }
    //         finally
    //         {
    //             var responseBytes = Encoding.UTF8.GetBytes(response);
    //             _channel.BasicPublish(exchange: "",
    //                 routingKey: props.ReplyTo,
    //                 basicProperties: replyProps,
    //                 body: responseBytes);

    //             _channel.BasicAck(deliveryTag: e.DeliveryTag,
    //                 multiple: false);



    //         }
    //     }


    // }


    public class RpcServer : BackgroundService
    {

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private readonly IServiceProvider _serviceProvider;



        public RpcServer(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _consumer = new EventingBasicConsumer(_channel);


        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Start();


        }

        public async void Start()
        {
            _channel.QueueDeclare(queue: "rpc_queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.BasicQos(
                prefetchSize: 0,
                prefetchCount: 1,
                global: false);

            _channel.BasicConsume(queue: "rpc_queue",
                autoAck: false,
                consumer: _consumer);


            _consumer.Received += ConsumerReceived;



        }



        private async void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {

            var response = "";

            var body = e.Body.ToArray();
            var props = e.BasicProperties;
            var replyProps = _channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;



            try
            {
                var message = Encoding.UTF8.GetString(body);

                var wee = _serviceProvider.GetService<IHttpClientFactory>();

                var client = wee.CreateClient();
                Console.WriteLine("WDWDDWDWD");


                var loggedUserName = await client.GetAsync("https://localhost:7096/get-logged-in-user-name");

                // var _response = await data.Content.ReadAsStringAsync();

                // var user = new ApplicationUser { UserName = _response };

                // response = JsonConvert.SerializeObject(_response);

                response = await loggedUserName.Content.ReadAsStringAsync();

                Console.WriteLine("Dane które zostana wyslane do RPC client : " + response);


            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                response = "NIE MA IMIENIA ZALOGOWANEGO USERA";
            }
            finally
            {
                var responseBytes = Encoding.UTF8.GetBytes(response);
                _channel.BasicPublish(exchange: "",
                    routingKey: props.ReplyTo,
                    basicProperties: replyProps,
                    body: responseBytes);

                _channel.BasicAck(deliveryTag: e.DeliveryTag,
                    multiple: false);



            }
        }


    }
}


