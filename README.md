**README - API_AMQP Project**

The `API_AMQP` project is a C# application that provides functionality to interact with RabbitMQ using the AMQP protocol. It includes features such as sending messages to exchanges, creating bindings between exchanges and queues, and retrieving messages from queues.

## Getting Started

To use the `API_AMQP` project, follow the steps below:

1. Ensure that RabbitMQ is installed and running on your local machine or the specified `HostName` and `Port`.
2. Clone or download the project files.
3. Open the project in your preferred C# development environment.

## Prerequisites

The following prerequisites are required to run the `API_AMQP` project:

- .NET Core SDK (version 2.2 or later)
- RabbitMQ server

## Configuration

The project provides default configuration values, but you can modify them as per your requirements. Open the `QueueIO.cs` file and locate the `QueueIO` class.

### Connection Configuration

You can customize the RabbitMQ connection settings by modifying the following properties:

- `HostName`: The hostname or IP address of the RabbitMQ server. Default value: `"localhost"`.
- `Port`: The port number for the RabbitMQ server. Default value: `5672`.
- `UserName`: The username to authenticate with the RabbitMQ server. Default value: `"guest"`.
- `Password`: The password to authenticate with the RabbitMQ server. Default value: `"guest"`.

### Exchange and Routing Configuration

The default exchange and routing key values are used when sending messages. You can modify them as needed:

- `Exchange`: The exchange name to publish messages. Default value: `"direct_ex"`.
- `RoutingKey`: The routing key for the messages. Default value: `"direct_key"`.

### Queue Configuration

The default queue configuration is used when creating bindings and retrieving messages:

- `Queue`: The queue name to interact with. Default value: `"notifications"`.

## Usage

The `QueueIO` class provides the following methods for interacting with RabbitMQ:

### `ToSend(CreateMessageViewModel model)`

This method sends a message to the specified exchange and routing key. It accepts a `CreateMessageViewModel` object that contains the message details. The method returns a boolean indicating whether the message was successfully sent.

Example usage:

```csharp
var queueIO = new QueueIO();

var model = new CreateMessageViewModel
{
    Exchange = "my_exchange",
    RoutingKey = "my_routing_key",
    MessageBody = "Hello, RabbitMQ!"
};

bool success = queueIO.ToSend(model);
if (success)
{
    Console.WriteLine("Message sent successfully.");
}
else
{
    Console.WriteLine("Failed to send the message.");
}
```

### `CreateBind(CreateBindViewModel model)`

This method creates a binding between an exchange and a queue. It accepts a `CreateBindViewModel` object that contains the binding details. The method returns a string indicating the success of the operation.

Example usage:

```csharp
var queueIO = new QueueIO();

var model = new CreateBindViewModel
{
    Exchange = "my_exchange",
    Queue = "my_queue",
    RoutingKey = "my_routing_key"
};

string result = queueIO.CreateBind(model);
Console.WriteLine(result);
```

### `GetMessage(string queue = "")`

This method retrieves a message from the specified queue. If no queue is provided, it uses the default queue specified in the `QueueIO` class. The method returns a `Message` object containing the message details.

Example usage:

```csharp
var queueIO = new QueueIO();

Message message = queueIO.GetMessage();
if (message.Id != null && message.Body != null)
{
    Console.WriteLine($"Received Message - ID:

 {message.Id}, Body: {message.Body}");
}
else
{
    Console.WriteLine("No messages available in the queue.");
}
```

## License

The `API_AMQP` project is released under the MIT License. You can find the detailed license information in the `LICENSE` file.

## Acknowledgments

This project utilizes the following libraries and technologies:

- RabbitMQ.Client library for interacting with RabbitMQ
- Newtonsoft.Json library for JSON serialization
- C# programming language and .NET Core framework
