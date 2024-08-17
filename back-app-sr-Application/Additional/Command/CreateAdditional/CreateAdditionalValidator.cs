using FluentValidation;

namespace back_app_sr_Application.Additional.Command.CreateAdditional;

public class CreateAdditionalValidator : AbstractValidator<CreateAdditionalCommand>
{
    public CreateAdditionalValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do adicional não pode ser vazio");
        RuleFor(x => x.Name).Length(2, 100).WithMessage("O nome do adicional deve ter entre 2 e 100 caracteres.");
        RuleFor(x => x.Value).NotEmpty().WithMessage("O valor do adicional não pode ser vazio");
        RuleFor(x => x.Value).GreaterThan(0).WithMessage("O valor do adicional não pode ser menor ou igual a zero");
    }
}