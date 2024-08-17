using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.User;

namespace back_app_sr.Infra.Repository.Interfaces;

public interface IUserRepository : IRepository<UserModel>
{
    Task<UserModel> GetUserByEmail(string email);
}