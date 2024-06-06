using Newtonsoft.Json;

namespace back_app_sr_Application.User.DTO;

public class LoggedUserDTO
{
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("role")]
    public string Role { get; set; }
    
    public LoggedUserDTO(string email, string role)
    {
        Email = email;
        Role = role;
    }
}