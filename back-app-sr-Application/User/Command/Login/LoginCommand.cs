using System.ComponentModel;
using back_app_sr_Application.User.DTO;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.User.Command.Login;

public class LoginCommand : IRequest<UserLoginResponseDTO>
{
    [JsonProperty("email")]
    [DefaultValue("System")]
    public string Email { get; set; } = string.Empty;
    [JsonProperty("password")]    
    [DefaultValue("System")]
    public string Password { get; set; } = string.Empty;
}