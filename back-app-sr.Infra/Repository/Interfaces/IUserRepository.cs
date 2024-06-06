using back_app_sr.Domain.Models;

namespace back_app_sr.Infra.Repository.Interfaces;

public interface IUserRepository : IRepository<UserModel>
{
    Task<UserModel> GetUserByEmail(string email);
}