using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQPublisher
{
    public class RabbitMQSender: IRabbitMQSender
    {
        public void SendMessage(string queue, string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = RabbitMQSettings.HostName,                
                UserName = RabbitMQSettings.UserName,
                Password = RabbitMQSettings.Password,                
            };

            //Cria a conexão
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queue,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}


