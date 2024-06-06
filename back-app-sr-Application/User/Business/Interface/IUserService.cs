using back_app_sr_Application.User.DTO;
using back_app_sr.Domain.Models;
namespace back_app_sr_Application.User.Business.Interface;

public interface IUserService
{
    UserModel CreateUser(string name, string password, string email);
    Task<UserDTO> Login(string email, string password);
}