using back_app_sr_Application.Additional.Service.Interface;
using MediatR;

namespace back_app_sr_Application.Additional.Command.CreateAdditional;

public class AdditionalCommandHandler : IRequestHandler<AdditionalCommand, string>
{
    private readonly IAdditionalService _additionalService;

    public AdditionalCommandHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public Task<string> Handle(AdditionalCommand request, CancellationToken cancellationToken)
    {
        var result = _additionalService.CreateAdditional(request.Name, request.Value);
        return Task.FromResult("Adicional criado com sucesso!");
    }
}