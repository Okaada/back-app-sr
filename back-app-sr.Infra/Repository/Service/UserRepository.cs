using back_app_sr.Domain.Models;
using back_app_sr.Infra.Context;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr.Infra.Repository.Service;

public class UserRepository : Repository<UserModel>, IUserRepository
{
    protected readonly ApplicationContext Context;
    public UserRepository(ApplicationContext context): base(context)
    {
        Context = context;
    }

    public Task<UserModel> GetUserByEmail(string email)
    {
        return Task.FromResult(Context.Users.FirstOrDefault(x => x.Email == email) ?? throw new KeyNotFoundException());
    }
}