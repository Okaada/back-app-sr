using back_app_sr_Application.User.Service.Interface;
using FluentValidation;
using MediatR;

namespace back_app_sr_Application.User.Command.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserService _userService;
    
    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException("Error", validationResult.Errors);
        var result = await _userService.DeleteUser(request.Id);
        return result;
    }
}