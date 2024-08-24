using Newtonsoft.Json;

namespace back_app_sr.WebApi.DTOs;

public class UserUpdateDTO
{
    [JsonProperty("username")] public string UserName { get; set; } = string.Empty;
    [JsonProperty("role")] public string Role { get; set; } = string.Empty;
    [JsonProperty("password")] public string Password { get; set; } = string.Empty;
    [JsonProperty("email")] public string Email { get; set; } = string.Empty;
}