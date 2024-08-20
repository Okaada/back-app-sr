using FluentValidation;

namespace back_app_sr_Application.User.Command.CreateUser;

public class CreateUserValidator: AbstractValidator<CreateUserCommand>
{

    public CreateUserValidator()
    {
#if !DEBUG
        RuleFor(cmd => cmd.Password)
            .NotEmpty().WithMessage("A senha não pode estar vazia")
            .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres")
            .Matches(@"[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
            .Matches(@"[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
            .Matches(@"\d").WithMessage("A senha deve conter pelo menos um número")
            .Matches(@"[\W_]").WithMessage("A senha deve conter pelo menos um caractere especial");
#else
        RuleFor(cmd => cmd.Password).NotEmpty();
#endif
        RuleFor(cmd => cmd.Email).NotEmpty();
        RuleFor(cmd => cmd.Username).NotEmpty();
        RuleFor(cmd => cmd.Role).NotEmpty();
    }
}