using back_app_sr_Application.Additional.Command.CreateAdditional;
using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr.Infra.Repository.Interfaces;
using MediatR;

namespace back_app_sr_Application.Additional.Command.DeleteAdditional;

public class DeleteAdditionalCommandHandler : IRequestHandler<DeleteAdditionalCommand, bool>
{
    private readonly IAdditionalService _additionalService;

    public DeleteAdditionalCommandHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public Task<bool> Handle(DeleteAdditionalCommand request, CancellationToken cancellationToken)
    {
        var result = _additionalService.DeleteAdditional(request.AdditionalId);
        return result;
    }
}