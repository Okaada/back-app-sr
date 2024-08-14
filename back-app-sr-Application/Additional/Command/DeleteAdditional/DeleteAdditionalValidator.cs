using FluentValidation;

namespace back_app_sr_Application.Additional.Command.DeleteAdditional;

public class DeleteAdditionalValidator : AbstractValidator<DeleteAdditionalCommand>
{
    public DeleteAdditionalValidator()
    {
        RuleFor(x => x.AdditionalId).NotEmpty().WithMessage("O ID do adicional não pode ser vazio");
        RuleFor(x => x.AdditionalId).GreaterThan(0).WithMessage("O ID do adicional não pode ser menor ou igual a zero");
    }
}