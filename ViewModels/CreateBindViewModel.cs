namespace API_AMQP.ViewModels;

public class CreateBindViewModel
{
    public string Queue { get; set; }
    public string Exchange { get; set; }
    public string RoutingKey { get; set; }
}
