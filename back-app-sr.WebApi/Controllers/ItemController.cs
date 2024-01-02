using System.Net;
using back_app_sr_Application.Item.Command;
using back_app_sr_Application.Item.Query.GetAllItems;
using back_app_sr_Application.Item.Query.GetItemById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [ProducesResponseType<int>((int)HttpStatusCode.Created)]
    [ProducesResponseType<int>((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateItem([FromBody] ItemCommand itemRequest)
    {
        var result = await _mediator.Send(itemRequest);
        return Created("/item", result);
    }

    [HttpGet]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllItems()
    {
        var result = await _mediator.Send(new GetAllItemsQuery());
        if (!result.Any())
            return NoContent();
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetItemById(int id)
    {
        var result = await _mediator.Send(new GetItemQuery {ItemId = id});
        if (result == null)
            return NoContent();
        
        return Ok(result);
    }
}