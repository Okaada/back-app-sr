using System.Net;
using back_app_sr_Application.Item.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("api/controller")]
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
        return Created("", result);
    }
}