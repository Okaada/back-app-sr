using back_app_sr_Application.User.Service.Interface;
using back_app_sr_Application.User.ViewModel;
using MediatR;

namespace back_app_sr_Application.User.Query.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponseViewModel>
{
    private readonly IUserService _userService;

    public GetUserByIdQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<UserResponseViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _userService.GetById(request.Id);
        if(result != null)
            return result;

        return new UserResponseViewModel();
    }
}