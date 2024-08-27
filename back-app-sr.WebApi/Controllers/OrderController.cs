using back_app_sr_Application.Order.Command.CreateOrderItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
// [Authorize]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _mediator.Send(command);

        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderItemById(Guid id)
    {
        // Método para recuperar o OrderItem criado
        return Ok();
    }
}