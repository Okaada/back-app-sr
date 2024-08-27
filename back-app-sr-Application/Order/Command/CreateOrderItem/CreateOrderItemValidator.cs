using FluentValidation;

namespace back_app_sr_Application.Order.Command;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemValidator()
    {
        RuleFor(x => x.TabId).NotEmpty().WithMessage("O número da mesa não pode ser vazio");
    }
}