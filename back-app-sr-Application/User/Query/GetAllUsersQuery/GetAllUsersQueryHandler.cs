using back_app_sr_Application.User.Service.Interface;
using back_app_sr_Application.User.ViewModel;
using MediatR;

namespace back_app_sr_Application.User.Query.GetAllUsersQuery;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseViewModel>>
{
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<IEnumerable<UserResponseViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await _userService.GetAllUsers();
        return result;
    }
}