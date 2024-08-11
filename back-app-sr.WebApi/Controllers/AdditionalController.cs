using System.Net;
using back_app_sr_Application.Additional.Command.CreateAdditional;
using back_app_sr_Application.Additional.Command.DeleteAdditional;
using back_app_sr_Application.Additional.Query.GetAdditionalById;
using back_app_sr_Application.Additional.Query.GetAllAdditionals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdditionalController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdditionalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType<int>((int)HttpStatusCode.Created)]
    [ProducesResponseType<int>((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateAdditional([FromBody] AdditionalCommand additionalRequest)
    {
        var result = await _mediator.Send(additionalRequest);
        return Created("/additional", result);
    }

    [HttpGet]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllAdditionals()
    {
        var result = await _mediator.Send(new GetAllAdditionalsQuery());
        if (!result.Any())
            return NoContent();

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAdditionalById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetAdditionalQuery {AdditionalId = id});
        if (result == null)
            return NoContent();
        
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType<int>((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteAdditional([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteAdditionalCommand { AdditionalId = id });
        if (!result)
            return NotFound();

        return Ok("Adicional deletado com sucesso!");
    }
}