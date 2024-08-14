using System.Net;
using back_app_sr_Application.Additional.Command.CreateAdditional;
using back_app_sr_Application.Additional.Command.DeleteAdditional;
using back_app_sr_Application.Additional.Command.UpdateAdditional;
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
    public async Task<IActionResult> CreateAdditional([FromBody] CreateAdditionalCommand createAdditionalRequest)
    {
        var result = await _mediator.Send(createAdditionalRequest);
        return Created($"/api/additional/{result}", result);
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
    
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateAdditional([FromRoute] int id, [FromBody] UpdateAdditionalCommand updateAdditionalRequest)
    {
        if (id != updateAdditionalRequest.AdditionalId)
        {
            return BadRequest("ID no URL não corresponde ao ID no corpo da requisição.");
        }

        var result = await _mediator.Send(updateAdditionalRequest);
        if (!result)
            return NotFound();

        return Ok("Adicional atualizado com sucesso!");
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType<int>((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteAdditional([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteAdditionalCommand { AdditionalId = id });

        return Ok(result);
    }
}