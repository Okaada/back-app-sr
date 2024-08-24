using System.Net;
using back_app_sr_Application.Item.Command.CreateItem;
using back_app_sr_Application.Item.Command.UpdateItem;
using back_app_sr_Application.Item.Query.GetAllItems;
using back_app_sr_Application.Item.Query.GetItemById;
using back_app_sr_Application.Item.ViewModel;
using back_app_sr.Domain.Models.Items;
using back_app_sr.WebApi.DTOs.Item;
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
    [ProducesResponseType(typeof(IEnumerable<ItemResponseViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllItems()
    {
        var result = await _mediator.Send(new GetAllItemsQuery());
        if (!result.Any())
            return NoContent();
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ItemResponseViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetItemById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetItemByIdQuery {ItemId = id});
        if (result.ItemId == 0)
            return NoContent();
        
        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ItemModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateItem([FromRoute] int id, [FromBody] UpdateItemDTO updateUpdateItemRequest)
    {
        var updateItem = new UpdateItemCommand
        {
            ItemId = id,
            Name = updateUpdateItemRequest.Name,
            Value = updateUpdateItemRequest.Value,
            Description = updateUpdateItemRequest.Description,
            IsActive = updateUpdateItemRequest.IsActive
        };
        
        var result = await _mediator.Send(updateItem);

        if (result.ItemId == 0)
            NoContent();
        
        return Ok(result);
    }
}