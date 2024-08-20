using back_app_sr_Application.User.Command.CreateUser;
using back_app_sr_Application.User.Service.Interface;
using back_app_sr_Application.User.ViewModel;
using FluentValidation;
using MediatR;

namespace back_app_sr_Application.User.Command.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserUpdateViewModel>
{
    private readonly IUserService _userService;
    
    public UpdateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UserUpdateViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException("Error", validationResult.Errors);
        var result = await _userService.UpdateUser(request.Id,request.Username, request.Password, request.Email, request.Role);
        return result;
    }
}