using FluentValidation;

namespace back_app_sr_Application.Order.Command.CreateOrderItem;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemValidator()
    {
        RuleFor(x => x.TabId).NotEmpty().WithMessage("O id da comanda não pode ser vazio");
        RuleFor(x => x.ItemId).NotEmpty().WithMessage("O id do item não pode ser vazio");
        RuleFor(x => x.ItemId).GreaterThan(0).WithMessage("O id do item deve ser maior que zero");
        RuleFor(x => x.Quantity).NotEmpty().WithMessage("A quantidade não pode ser vazia");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("A quantidade deve ser maior que zero");
    }
}