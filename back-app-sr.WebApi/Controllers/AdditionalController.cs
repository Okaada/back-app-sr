using System.Net;
using back_app_sr_Application.Additional.Command.CreateAdditional;
using back_app_sr_Application.Additional.Command.DeleteAdditional;
using back_app_sr_Application.Additional.Command.UpdateAdditional;
using back_app_sr_Application.Additional.Query.GetAdditionalById;
using back_app_sr_Application.Additional.Query.GetAllAdditionals;
using back_app_sr_Application.Additional.ViewModel;
using back_app_sr.WebApi.DTOs.Additional;
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
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateAdditional([FromBody] CreateAdditionalCommand createAdditionalRequest)
    {
        var result = await _mediator.Send(createAdditionalRequest);
        return Created("/additional", result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AdditionalResponseViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAllAdditionals()
    {
        var result = await _mediator.Send(new GetAllAdditionalsQuery());
        if (!result.Any())
            return NoContent();

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AdditionalResponseViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAdditionalById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetAdditionalByIdQuery {AdditionalId = id});
        if (result.AdditionalId == 0)
            return NoContent();
        
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AdditionalResponseViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateAdditional([FromRoute] int id, [FromBody] UpdateAdditionalDTO updateAdditionalRequest)
    {
        var updateAdditional = new UpdateAdditionalCommand
        {
            AdditionalId = id,
            Name = updateAdditionalRequest.Name,
            Value = updateAdditionalRequest.Value
        };

        var result = await _mediator.Send(updateAdditional);

        if (result.AdditionalId == 0)
            return NoContent();

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeleteAdditionalViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAdditional([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteAdditionalCommand { AdditionalId = id });

        if (result.Name == null)
            return NoContent();
        
        return Ok(result);
    }
}