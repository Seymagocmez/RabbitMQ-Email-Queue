# RabbitMQ Email Sender in C#

This C# project listens to a RabbitMQ queue, processes messages, and sends them as HTML-formatted emails with embedded images via SMTP.

## What is this project used for?

This project automates the process of sending emails based on messages received from a queue system (RabbitMQ). It’s useful for scenarios where you need to send emails to multiple users automatically, such as:
- Sending notification emails
- Delivering confirmation messages after a user action (e.g., signing up or making a purchase)
- Automating newsletters or system alerts

Instead of sending emails manually, the system listens for new messages in the queue and sends them out as emails formatted in HTML with images and other rich content.

## Features
- Listens to RabbitMQ message queue (`mail-kuyruk`)
- Sends emails in HTML format
- Supports embedded images in the email body

## Requirements
- .NET 6.0+
- RabbitMQ (3.6.9)
- SMTP server (e.g., Office 365)

## Setup

1. **Clone the Repository:**
    ```bash
    git clone https://github.com/Seymagocmez/RabbitMQ-Email-Queue.git
    cd your-repo-name
    ```

2. **Create a RabbitMQ Server:**
    If you haven't already, you need to set up a RabbitMQ server. Follow [this guide](https://medium.com/@ademolguner/rabbitmq-nedir-nas%C4%B1l-kurulur-nas%C4%B1l-konfig%C3%BCre-edilir-ea596a7c1c08) to install and configure RabbitMQ.

3. **Update SMTP Credentials:**
    Open `Program.cs` and replace the placeholders with your SMTP server credentials:
    ```csharp
    Credentials = new System.Net.NetworkCredential("your-email@outlook.com", "your_password")
    ```

4. **Configure RabbitMQ:**
    Ensure RabbitMQ is running locally or update the `HostName`, `Port`, `UserName`, and `Password` in the `ConnectionFactory` configuration:
    ```csharp
    var factory = new ConnectionFactory()
    {
        HostName = "localhost",
        UserName = "guest",
        Password = "guest",
        Port = 5672
    };
    ```

5. **Run the Project:**
    ```bash
    dotnet run
    ```

## Usage
- Messages from the `mail-kuyruk` queue will be processed and sent as emails.
- The email body supports HTML and can include embedded images.

## Example HTML Email
```html
<h1>Welcome!</h1>
<p>This is an <b>HTML-formatted</b> email with an embedded image:</p>
<img src="cid:EmbeddedImage" />
