namespace back_app_sr_Application.User.DTO;

public class UserLoginResponseDTO
{
    public string Token { get; set; }

    public UserLoginResponseDTO(string token)
    {
        Token = token;
    }
}