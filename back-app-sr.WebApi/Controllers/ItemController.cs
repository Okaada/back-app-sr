using System.Net;
using back_app_sr_Application.Item.Command.CreateItem;
using back_app_sr_Application.Item.Command.DeleteItem;
using back_app_sr_Application.Item.Command.UpdateItem;
using back_app_sr_Application.Item.Query.GetAllActiveItems;
using back_app_sr_Application.Item.Query.GetActiveItemById;
using back_app_sr.Domain.Models.Items;
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
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateItem([FromBody] CreateItemCommand createItemRequest)
    {
        var result = await _mediator.Send(createItemRequest);
        return Created("/item", result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ItemModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllActiveItems()
    {
        var result = await _mediator.Send(new GetAllActiveItemsQuery());
        if (!result.Any())
            return NoContent();
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ItemModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetActiveItemById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetActiveItemByIdQuery {ItemId = id});
        if (result == null)
            return NoContent();
        
        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ItemModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateItem([FromRoute] int id, [FromBody] UpdateItemCommand updateItemRequest)
    {
        if (id != updateItemRequest.ItemId)
            return BadRequest("ID no URL não corresponde ao ID no corpo da requisição.");

        var result = await _mediator.Send(updateItemRequest);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteItem([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteItemCommand { ItemId = id });

        return Ok(result);
    }
}