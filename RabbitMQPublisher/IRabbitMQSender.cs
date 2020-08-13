using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQPublisher
{
    public interface IRabbitMQSender
    {
        void SendMessage(string queue, string message);
    }
}
