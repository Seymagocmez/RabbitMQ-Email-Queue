using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using VbtInternEmailQueue;

internal class Program
{
    private static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
            Port = 5672,
        };

        using (var connection = factory.CreateConnection()) // 1st using block for connection
        {
            using (var channel = connection.CreateModel()) // 2nd using block for channel
            {
                channel.QueueDeclare("mail-kuyruk",
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

                List<string> emailAddresses = new List<string>
                {
                    "gocmezseyma@gmail.com",
                    
                };

                List<MessageModel> messageModels = new List<MessageModel>();

                MessageModel model = new MessageModel();
                model.mail = "gocmezseyma@gmail.com";
                messageModels.Add(model);

                foreach (var mail in emailAddresses)
                {
                    MessageModel model2 = new MessageModel();
                    model2.mail = mail;
                    model2.message = $"{model2.message} - {Guid.NewGuid()}"; // Generate a unique message
                    messageModels.Add(model2);
                }

                // Now, this part is still inside the 'channel' scope, so you can use the channel here
                foreach (var messages in messageModels)
                {
                    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(messages));
                    channel.BasicPublish(string.Empty, "mail-kuyruk", null, body); // 'channel' is in scope here
                }
            } // Channel gets disposed here, but we are done using it and it helps to free up resources. 
        }
    }
}
