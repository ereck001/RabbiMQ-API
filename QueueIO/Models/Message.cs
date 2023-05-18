namespace API_AMQP.Models;

public class Message
{
    public Guid? Id { get; set; }
    public string? Body { get; set; }

    public static Message FromJson(string json)
    {
        return Newtonsoft
            .Json.JsonConvert
            .DeserializeObject<Message>(json);
    }
}