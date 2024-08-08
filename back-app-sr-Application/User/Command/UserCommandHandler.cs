using back_app_sr_Application.User.Service.Interface;
using MediatR;

namespace back_app_sr_Application.User.Command;

public class UserCommandHandler : IRequestHandler<UserCommand, string>
{
    private readonly IUserService _userService;
    
    public UserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public Task<string> Handle(UserCommand request, CancellationToken cancellationToken)
    {

        var result = _userService.CreateUser(request.Username, request.Password, request.Email);
        return Task.FromResult("Usuário criado com sucesso!");
    }
}