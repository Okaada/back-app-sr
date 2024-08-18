using FluentValidation;

namespace back_app_sr_Application.Item.Command.DeleteItem;

public class DeleteItemValidator : AbstractValidator<DeleteItemCommand>
{
    public DeleteItemValidator()
    {
        RuleFor(x => x.ItemId).NotEmpty().WithMessage("O ID do item não pode ser vazio");
        RuleFor(x => x.ItemId).GreaterThan(0).WithMessage("O ID do item não pode ser menor ou igual a zero");
    }
}