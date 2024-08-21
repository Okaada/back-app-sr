using FluentValidation;

namespace back_app_sr_Application.Item.Command.CreateItem;

public class CreateItemValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do item não pode ser vazio.");
        RuleFor(x => x.Name).Length(2, 100).WithMessage("O nome do item deve ter entre 2 e 100 caracteres.");
        RuleFor(x => x.Value).NotEmpty().WithMessage("O valor do item não pode ser vazio.");
        RuleFor(x => x.Value).GreaterThan(0).WithMessage("O valor do item não pode ser menor ou igual a zero.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("A descrição do item não pode ser vazia.");
        RuleFor(x => x.Description).Length(2, 250).WithMessage("A descrição do item deve ter entre 2 e 250 caracteres.");
    }
}