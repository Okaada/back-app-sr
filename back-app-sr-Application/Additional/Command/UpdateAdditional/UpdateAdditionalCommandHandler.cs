using System.ComponentModel.DataAnnotations;
using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using MediatR;

namespace back_app_sr_Application.Additional.Command.UpdateAdditional;

public class UpdateAdditionalCommandHandler : IRequestHandler<UpdateAdditionalCommand, UpdateAdditionalViewModel>
{
    private readonly IAdditionalService _additionalService;

    public UpdateAdditionalCommandHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public async Task<UpdateAdditionalViewModel> Handle(UpdateAdditionalCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateAdditionalValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
            throw new FluentValidation.ValidationException("Error", validation.Errors);
        
        var result = await _additionalService.UpdateAdditional(request.AdditionalId, request.Name, request.Value);
        return result;
    }
}