using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using MediatR;

namespace back_app_sr_Application.Additional.Query.GetAdditionalById;

public class GetAdditionalQueryHandler : IRequestHandler<GetAdditionalQuery, AdditionalViewModel>
{
    private readonly IAdditionalService _additionalService;

    public GetAdditionalQueryHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public async Task<AdditionalViewModel> Handle(GetAdditionalQuery request, CancellationToken cancellationToken)
    {
        var result = await _additionalService.GetAdditionalById(request.AdditionalId);
        return result;
    }
}