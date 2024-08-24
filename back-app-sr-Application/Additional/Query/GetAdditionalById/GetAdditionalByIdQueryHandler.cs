using System.ComponentModel.DataAnnotations;
using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using FluentValidation;
using MediatR;

namespace back_app_sr_Application.Additional.Query.GetAdditionalById;

public class GetAdditionalByIdQueryHandler : IRequestHandler<GetAdditionalByIdQuery, AdditionalResponseViewModel>
{
    private readonly IAdditionalService _additionalService;

    public GetAdditionalByIdQueryHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public async Task<AdditionalResponseViewModel> Handle(GetAdditionalByIdQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetAdditionalByIdValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validation.IsValid)
            throw new FluentValidation.ValidationException("Error", validation.Errors);

        var result = await _additionalService.GetAdditionalById(request.AdditionalId);
        return result;
    }
}