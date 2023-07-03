namespace API_AMQP.Models;

public class Message
{
    public Guid? Id { get; set; }
    public string? Type { get; set; }
    public string? Body { get; set; }

    public static Message FromJson(string json)
    {
        var message = Newtonsoft
            .Json.JsonConvert
            .DeserializeObject<Message>(json);

        if (message == null)
        {
            message = new();
            message.Body = "mensagem vazía";
        }    

        return  message;
    }
}