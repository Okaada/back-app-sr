using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace back_app_sr_Application.Additional.Command.CreateAdditional;

public class CreateAdditionalCommandHandler : IRequestHandler<CreateAdditionalCommand, CreateAdditionalViewModel>
{
    private readonly IAdditionalService _additionalService;

    public CreateAdditionalCommandHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public async Task<CreateAdditionalViewModel> Handle(CreateAdditionalCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateAdditionalValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
            throw new ValidationException("Error", validation.Errors);

        var result = await _additionalService.CreateAdditional(request.Name, request.Value);
        return result;
    }
}