using back_app_sr.Domain.Models;

namespace back_app_sr_Application.User.Service.Interface;

public interface IUserService
{
    UserModel CreateUser(string name, string password, string email);
}