using back_app_sr_Application.User.DTO;
using back_app_sr_Application.User.Service.Interface;
using MediatR;

namespace back_app_sr_Application.User.Command.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, UserLoginResponseDTO>
{
    private readonly IUserService _userService;

    public LoginCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UserLoginResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
    {   
        var result = await _userService.Login(request.Email, request.Password);

        return result;
    }
}