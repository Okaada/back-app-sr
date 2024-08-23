using System.Net;
using back_app_sr_Application.User.Command.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> UserLogin([FromBody] LoginCommand loginRequest)
    {
        var result = await _mediator.Send(loginRequest);
        if (string.IsNullOrEmpty(result.Token))
            return Unauthorized();
        return Ok(result);
    }
}