using back_app_sr_Application.User.ViewModel;
using MediatR;

namespace back_app_sr_Application.User.Query.GetAllUsersQuery;

public class GetAllUsersQuery : IRequest<IEnumerable<UserResponseViewModel>>
{
    
}