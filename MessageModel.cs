using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VbtInternEmailQueue
{
    public class MessageModel
    {
        public String mail { get; set; }
        public String message { get; set; } = "RabbitMQ Sending Email Queue, VBT Software Internship Project, Şeyma Göçmez. Thanks for viewing and listening :)";
        public String subject { get; set; } = "Şeyma Göçmez, Rabbit MQ Project";
    }
}
