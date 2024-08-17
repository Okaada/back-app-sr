using Microsoft.AspNetCore.Identity;

namespace back_app_sr.Domain.Models.User;

public class UserModel
{
    public Guid UserId { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    public string Email { get; private set; }
    
    private UserModel(){}
    
    public UserModel(Guid guid, string username, string password, string role, string email)
    {
        UserId = guid;
        Username = username;
        Password = password;
        Role = role;
        Email = email;
    }

    public static string HashPassword(string password)
    {
        var hasher = new PasswordHasher<UserModel>();
        return hasher.HashPassword( null! , password);
    }

    public bool VerifyPassword(string password)
    {
        var hasher = new PasswordHasher<UserModel>();
        var result = hasher.VerifyHashedPassword(null!, Password, password);
        return result == PasswordVerificationResult.Success;
    }

    public void UpdateName(string userName) => Username = userName;
    
    public void UpdateEmail(string email) => Email = email;
    
    public void UpdateRole(string role) => Role = role;

    public void UpdatePassword(string newPassword)
    {
        Password = HashPassword(newPassword);
    }

}