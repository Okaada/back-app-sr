using System.Net;
using back_app_sr_Application.User.Command.CreateUser;
using back_app_sr_Application.User.Command.DeleteUser;
using back_app_sr_Application.User.Command.UpdateUser;
using back_app_sr_Application.User.Query.GetAllUsersQuery;
using back_app_sr_Application.User.Query.GetUserById;
using back_app_sr.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin")]
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
    [ProducesResponseType<int>((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType<int>((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserRequest)
    {
        var result = await _mediator.Send(createUserRequest);
        return Created("/users", result);
    }
    
    [HttpGet]
    [ProducesResponseType<int>((int)HttpStatusCode.Created)]
    [ProducesResponseType<int>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<int>((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType<int>((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> GetAllUser()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<int>((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType<int>((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery{Id = id});
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<int>((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType<int>((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserUpdateDTO updateDto)
    {
        var cmd = new UpdateUserCommand
        {
            Role = updateDto.Role,
            Email = updateDto.Email,
            Password = updateDto.Password,
            Username = updateDto.UserName,
            Id = id
        };
        var result = await _mediator.Send(cmd);
        return Ok(result);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType<int>((int)HttpStatusCode.OK)]
    [ProducesResponseType<int>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<int>((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType<int>((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new DeleteUserCommand { Id = id });
        if (result)
            return Ok(result);

        return BadRequest();
    }
}