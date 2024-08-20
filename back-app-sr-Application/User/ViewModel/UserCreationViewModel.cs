using Newtonsoft.Json;

namespace back_app_sr_Application.User.ViewModel;

public class UserCreationViewModel
{
    [JsonProperty("name")] public string Email { get; set; } = string.Empty;
    [JsonProperty("role")] public string Role { get; set; } = string.Empty;
}