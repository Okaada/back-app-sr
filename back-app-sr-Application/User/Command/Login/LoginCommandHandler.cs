using back_app_sr_Application.User.Business.Interface;
using back_app_sr_Application.User.DTO;
using MediatR;

namespace back_app_sr_Application.User.Command.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedUserDTO>
{
    private readonly IUserService _userService;
    
    public LoginCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<LoggedUserDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
    {   
        var result = await _userService.Login(request.Email, request.Password);

        return new LoggedUserDTO(result.Email, result.Role);
    }
}