using back_app_sr_Application.User.Service.Interface;
using back_app_sr_Application.User.ViewModel;
using FluentValidation;
using MediatR;

namespace back_app_sr_Application.User.Command.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserCreationViewModel>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UserCreationViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException("Error", validationResult.Errors);
        var result = await _userService.CreateUser(request.Username, request.Password, request.Email, request.Role);
        return result;

    }
}