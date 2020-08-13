using System;

namespace RabbitMQPublisher
{
    public static class RabbitMQSettings
    {
        public static string HostName { get { return "rabbitmq"; } }
        public static string UserName { get { return "guest"; } }
        public static string Password { get { return "guest"; } }
        public static string QueueName { get { return @"MessageMongoDB"; } }
    }
}
