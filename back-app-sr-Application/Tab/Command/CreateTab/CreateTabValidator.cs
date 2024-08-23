using FluentValidation;

namespace back_app_sr_Application.Tab.Command.CreateTab;

public class CreateTabValidator : AbstractValidator<CreateTabCommand>
{
    public CreateTabValidator()
    {
        RuleFor(x => x.TableNumber).GreaterThan(0).WithMessage("O número da mesa não pode ser menor ou igual a 0");
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome não pode estar vazio");
    }
}