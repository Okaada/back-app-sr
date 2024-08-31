using System.Net;
using back_app_sr_Application.Order.Command.CreateOrderItem;
using back_app_sr_Application.Order.Query.GetAllOrderItem;
using back_app_sr_Application.Order.Query.GetOrderItemById;
using back_app_sr_Application.Order.ViewModel;
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
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateOrderItems([FromBody] CreateOrderItemCommand command)
    {
        var result = await _mediator.Send(command);

        return Created("/order", result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderItemResponseViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllOrderItem()
    {
        var result = await _mediator.Send(new GetAllOrderItemsQuery());
        if (!result.Any())
            return NoContent();

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrderItemResponseViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetOrderItemById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetOrderItemByIdQuery() {Id = id});
        if (result == null)
            return NoContent();
        
        return Ok(result);
    }
}