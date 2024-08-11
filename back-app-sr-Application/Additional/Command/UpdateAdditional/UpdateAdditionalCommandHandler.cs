using back_app_sr_Application.Additional.Service.Interface;
using MediatR;

namespace back_app_sr_Application.Additional.Command.UpdateAdditional;

public class UpdateAdditionalCommandHandler : IRequestHandler<UpdateAdditionalCommand, bool>
{
    private readonly IAdditionalService _additionalService;

    public UpdateAdditionalCommandHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public async Task<bool> Handle(UpdateAdditionalCommand request, CancellationToken cancellationToken)
    {
        var result = await _additionalService.UpdateAdditional(request.AdditionalId, request.Name, request.Value);
        return result;
    }
}