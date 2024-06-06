using System.Security.Claims;
using back_app_sr_Application.User.Command.Login;
using back_app_sr.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("login")]

public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> UserLogin([FromBody] LoginCommand loginRequest)
    {
        var result = await _mediator.Send(loginRequest);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, result.Email),
            new(ClaimTypes.Role, result.Role)
        };
        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        
        var authProperties = new AuthenticationProperties();

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(identity), 
            authProperties);
        
        return Ok();
    }

}