namespace back_app_sr_Application.User.DTO;

public class UserDTO
{
    public string Email { get; set; }
    public string Role { get; set; }
    
    public UserDTO(string email, string role)
    {
        Email = email;
        Role = role;
    }
}