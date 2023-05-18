using API_AMQP.ViewModels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace API_AMQP.Models;
public class QueueIO
{
    public QueueIO()
    {
        Factory = new ConnectionFactory()
        {
            HostName = this.HostName, 
            Port = this.Port,           
            UserName = this.UserName,
            Password = this.Password
        };
    }
    public string HostName { get; set; } = "localhost";
    public int Port { get; set; } = 5672;
    public string UserName { get; set; } = "guest";
    public string Password { get; set; } = "guest";
    public string Exchange { get; set; } = "direct_ex";
    public string RoutingKey { get; set; } = "direct_key";
    public string Queue { get; set; } = "notifications";
    public ConnectionFactory Factory { get; set; }

    public bool ToSend(CreateMessageViewModel model)
    {
        using var connection = Factory.CreateConnection();
        using var channel = connection.CreateModel();

        if (model.Exchange != null)
        {
            this.Exchange = model.Exchange;
            channel.ExchangeDeclare(this.Exchange, type: "direct",durable: false);
        }

        if (model.RoutingKey != null)
            this.RoutingKey = model.RoutingKey;

        var message = new Message
        {
            Id = Guid.NewGuid(),
            Body = model.MessageBody
        };
        var objToSend = new Dictionary<string, object> {
            {"id", message.Id},
            {"body", message.Body}
        };

        var jsonToSend = JsonConvert.SerializeObject(objToSend);

        channel.BasicPublish(this.Exchange,
                             this.RoutingKey,
                             null,
                             Encoding.UTF8.GetBytes(jsonToSend));
        return true;
    }    
    public string CreateBind(CreateBindViewModel model)
    {
        using var connection = Factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(model.Exchange, type: "direct");
        channel.QueueDeclare(model.Queue, exclusive:false, autoDelete:false);
        channel.QueueBind(model.Queue,model.Exchange,model.RoutingKey);

        return $"Criado o bind da Exchange {model.Exchange} na fila {model.Queue} com {model.RoutingKey}";
    }
    public Message GetMessage(string queue = "")
    {
        using var connection = this.Factory.CreateConnection();
        using var channel = connection.CreateModel();

        if (queue != "" && queue != null)
        {
            this.Queue = queue;
            channel.QueueDeclare(queue, exclusive: false, autoDelete: false);
        }

        var data = channel.BasicGet(this.Queue, true);

        if (data != null)
        {
            // Converte o conteúdo da mensagem em uma string JSON
            var json = Encoding.UTF8.GetString(data.Body.ToArray());

            var message = Message.FromJson(json);

            return message;
        }
        else
        {
            var message = new Message
            {
                Id = null,
                Body = null
            };

            return message;
        }
    }
}
