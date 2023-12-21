using Microsoft.AspNetCore.Mvc;

namespace back_app_sr.WebApi.Controllers;

[ApiController]
[Route("login")]

public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult UserLogin([FromBody] string loginRequest)
    {
        return Ok();
    }

}