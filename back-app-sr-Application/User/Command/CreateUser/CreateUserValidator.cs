using FluentValidation;

namespace back_app_sr_Application.User.Command.CreateUser;

public class CreateUserValidator: AbstractValidator<CreateUserCommand>
{

    public CreateUserValidator()
    {
        RuleFor(cmd => cmd.Password)
            .NotEmpty().WithMessage("A senha não pode estar vazia")
            .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres")
            .Matches(@"[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
            .Matches(@"[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
            .Matches(@"\d").WithMessage("A senha deve conter pelo menos um número")
            .Matches(@"[\W_]").WithMessage("A senha deve conter pelo menos um caractere especial");
        RuleFor(cmd => cmd.Email)
            .NotEmpty().WithMessage("O E-mail é obrigatório");
        
        const string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            RuleFor(cmd => cmd.Email)
                .Matches(pattern)
                .WithMessage("O E-mail deve estar no formato válido (email@email.com)");
        RuleFor(cmd => cmd.Username).NotEmpty();
        RuleFor(cmd => cmd.Role).NotEmpty();
    }
}