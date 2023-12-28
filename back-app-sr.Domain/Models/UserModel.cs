namespace back_app_sr.Domain.Models;

public class UserModel
{
    public Guid UserId { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    public string Email { get; private set; }

    public UserModel(string username, string password, string role, string email)
    {
        UserId = Guid.NewGuid();
        Username = username;
        Password = password;
        Role = role;
        Email = email;
    }
}