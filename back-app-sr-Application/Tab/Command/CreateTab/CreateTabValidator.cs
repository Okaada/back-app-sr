using FluentValidation;

namespace back_app_sr_Application.Tab.Command.CreateTab;

public class CreateTabValidator : AbstractValidator<CreateTabCommand>
{
    public CreateTabValidator()
    {
        RuleFor(x => x.TabType).NotEmpty().WithMessage("O tipo da comanda não pode ser vazio");
        RuleFor(x => x.TableNumber).GreaterThanOrEqualTo(0).WithMessage("O número da mesa não pode ser menor que 0");
    }
}