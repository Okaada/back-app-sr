using back_app_sr.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("login")]

public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult UserLogin([FromBody] LoginDTO loginRequest)
    {
        return Ok();
    }

}