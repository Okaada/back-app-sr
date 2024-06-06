using back_app_sr_Application.User.DTO;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.User.Command.Login;

public class LoginCommand : IRequest<LoggedUserDTO>
{
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("password")]
    public string Password { get; set; }
}