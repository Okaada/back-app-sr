using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.User;
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
    
    public async Task<UserModel> GetUserByEmail(string email)
    {
        return await Task.FromResult(Context.Users.FirstOrDefault(x => x.Email == email));
    }
}