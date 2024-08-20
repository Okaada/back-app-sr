using System.Net;
using back_app_sr_Application.Tab.Command.CreateTab;
using back_app_sr_Application.Tab.Query.GetAllTabs;
using back_app_sr_Application.Tab.Query.GetTabsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TabController : ControllerBase
{
    private readonly IMediator _mediator;
    public TabController(IMediator mediator)
    {
        _mediator = mediator;  
    }
    
    [HttpPost]
    [ProducesResponseType<int>((int)HttpStatusCode.Created)]
    [ProducesResponseType<int>((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateTab([FromBody] CreateTabCommand createTabRequest)
    {
        var result = await _mediator.Send(createTabRequest);
        return Created("/tab", result);
    }
    
    [HttpGet]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllTabs()
    {
        var result = await _mediator.Send(new GetAllTabsQuery());
        if (!result.Any())
            return NoContent();
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetTabById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetTabByIdQuery {TabId = id});
        if (result.TabId == Guid.Empty)
            return NoContent();
        
        return Ok(result);
    }
}