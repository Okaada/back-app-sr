using System.Net;
using back_app_sr_Application.User.Command;
using back_app_sr_Application.User.Command.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers; 

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [ProducesResponseType<int>((int)HttpStatusCode.Created)]
    [ProducesResponseType<int>((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] UserCommand userRequest)
    {
        var result = await _mediator.Send(userRequest);
        return Created("/users", result);
    }
}