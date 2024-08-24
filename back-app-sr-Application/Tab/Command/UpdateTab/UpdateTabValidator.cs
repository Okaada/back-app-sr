using FluentValidation;

namespace back_app_sr_Application.Tab.Command.UpdateTab;

public class UpdateTabValidator : AbstractValidator<UpdateTabCommand>
{
    public UpdateTabValidator()
    {
        RuleFor(x => x.TableNumber).GreaterThan(0).WithMessage("O número da mesa não pode ser menor ou igual a 0");
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome não pode estar vazio");
 
        var conditions = new List<string> { "Aberta", "Fechada", "Inativa" };
        RuleFor(x => x.Status)
            .Must(x => conditions.Contains(x))
            .WithMessage("Por favor, utilize os seguintes status: " + string.Join(", ", conditions));
    }
}