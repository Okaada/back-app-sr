using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using MediatR;

namespace back_app_sr_Application.Additional.Command.DeleteAdditional;

public class DeleteAdditionalCommandHandler : IRequestHandler<DeleteAdditionalCommand, DeleteAdditionalViewModel>
{
    private readonly IAdditionalService _additionalService;

    public DeleteAdditionalCommandHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public async Task<DeleteAdditionalViewModel> Handle(DeleteAdditionalCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteAdditionalValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
            throw new FluentValidation.ValidationException("Error", validation.Errors);

        var result = await _additionalService.DeleteAdditional(request.AdditionalId);

        return result;
    }
}