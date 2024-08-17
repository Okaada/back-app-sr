using back_app_sr_Application.User.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.User.Command.CreateUser;

public class CreateUserCommand : IRequest<UserCreationViewModel>
{
    [JsonProperty("username")]
    public string Username { get; set; } = string.Empty;
    [JsonProperty("password")]
    public string Password { get; set; } = string.Empty;
    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;
    [JsonProperty("role")]
    public string Role { get; set; } = string.Empty;
    
}
