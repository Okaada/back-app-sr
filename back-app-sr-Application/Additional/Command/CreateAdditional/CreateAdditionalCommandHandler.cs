using back_app_sr_Application.Additional.Service.Interface;
using MediatR;

namespace back_app_sr_Application.Additional.Command.CreateAdditional;

public class CreateAdditionalCommandHandler : IRequestHandler<CreateAdditionalCommand, string>
{
    private readonly IAdditionalService _additionalService;

    public CreateAdditionalCommandHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public Task<string> Handle(CreateAdditionalCommand request, CancellationToken cancellationToken)
    {
        var result = _additionalService.CreateAdditional(request.Name, request.Value);
        return Task.FromResult("Adicional criado com sucesso!");
    }
}