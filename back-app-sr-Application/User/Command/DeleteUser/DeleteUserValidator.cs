using back_app_sr_Application.User.Command.CreateUser;
using FluentValidation;

namespace back_app_sr_Application.User.Command.DeleteUser;

public class DeleteUserValidator: AbstractValidator<DeleteUserCommand>
{

    public DeleteUserValidator()
    {
        RuleFor(cmd => cmd.Id).NotEmpty();
    }
}