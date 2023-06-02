namespace API_AMQP.ViewModels;

public class CreateMessageViewModel
{
    public string MessageBody { get; set; }
    public string? Type { get; set; }
    public string? Exchange { get; set; }
    public string? RoutingKey { get; set; }
}
