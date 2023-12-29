using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.User.Command;

public class UserCommand : IRequest<string>
{
    [JsonProperty("username")]
    public string Username { get; set; } = string.Empty;
    [JsonProperty("password")]
    public string Password { get; set; } = string.Empty;
    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;
}
