using back_app_sr_Application.Additional.ViewModel;
using FluentValidation;

namespace back_app_sr_Application.Additional.Query.GetAdditionalById;

public class GetAdditionalByIdValidator : AbstractValidator<GetAdditionalByIdQuery>
{
    public GetAdditionalByIdValidator()
    {
        RuleFor(x => x.AdditionalId).NotEmpty().WithMessage("O ID do adicional não pode ser vazio");
        RuleFor(x => x.AdditionalId).GreaterThan(0).WithMessage("O ID do adicional não pode ser menor ou igual a zero");
    }
}