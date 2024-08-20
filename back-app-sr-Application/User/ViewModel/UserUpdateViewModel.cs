using Newtonsoft.Json;

namespace back_app_sr_Application.User.ViewModel;

public class UserUpdateViewModel
{
    [JsonProperty("username")] public string Username { get; set; } = string.Empty;
    [JsonProperty("email")] public string Email { get; set; } = string.Empty;
    [JsonProperty("role")] public string Role { get; set; } = string.Empty;
}