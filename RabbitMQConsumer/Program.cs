using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQPublisher;
using System;
using System.Text;

namespace RabbitMQConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiveMessage(RabbitMQSettings.QueueName);
        }

        public static void ReceiveMessage(string queue)
        {

            //Cria a conexão com o RabbitMq
            var factory = new ConnectionFactory()
            {
                HostName = RabbitMQSettings.HostName,
                UserName = RabbitMQSettings.UserName,
                Password = RabbitMQSettings.Password,
            };
            //var factory = new ConnectionFactory() { HostName = "rabbitmq" }; // local=> HostName = "localhost"
            //Cria a conexão
            try
            {
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: queue,
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
