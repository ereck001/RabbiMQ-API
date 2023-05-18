using API_AMQP.Models;
using API_AMQP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_AMQP.Controllers;

public class HomeController : ControllerBase
{
    [HttpGet("NextMsg")]
    [HttpGet("NextMsg/{queue}")]
    public IActionResult GetNextMessage(string queue)
    {
        var consumer = new QueueIO();
        var message = consumer.GetMessage(queue);

        if (message.Id != null)
        {
            return Ok(message.Body);
        }
        else
        {
            return Ok("Sem mensagens");
        }
    }
    [HttpPost("ToSend")]
    public IActionResult ToSend(
        [FromBody] CreateMessageViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest("Erro na requisição");

        var sender = new QueueIO();
        var ready = sender.ToSend(model);

        if (ready)
            return Ok("Enviado com sucesso!");

        return BadRequest("Erro interno no servidor");
    }

    [HttpPost("bind")]
    public IActionResult CreateBind([FromBody] CreateBindViewModel model)
    {
        var sender = new QueueIO();
        var res = sender.CreateBind(model);

        return Ok(res);
    }
}