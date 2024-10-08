﻿using FluentValidation;

namespace back_app_sr_Application.Additional.Command.UpdateAdditional;

public class UpdateAdditionalValidator : AbstractValidator<UpdateAdditionalCommand>
{
    public UpdateAdditionalValidator()
    {  
        RuleFor(x => x.AdditionalId).NotEmpty().WithMessage("O ID do adicional é obrigatório.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do adicional é obrigatório.");
        RuleFor(x => x.Name).Length(2, 100).WithMessage("O nome do adicional deve ter entre 2 e 100 caracteres.");
        RuleFor(x => x.Value).NotEmpty().WithMessage("O valor do adicional não pode ser vazio");
        RuleFor(x => x.Value).GreaterThan(0).WithMessage("O valor do adicional não pode ser menor ou igual a zero");
    }
}