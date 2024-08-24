using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using MediatR;

namespace back_app_sr_Application.Additional.Query.GetAllAdditionals;

public class GetAllAdditionalsQueryHandler : IRequestHandler<GetAllAdditionalsQuery, IEnumerable<AdditionalResponseViewModel>>
{
    private readonly IAdditionalService _additionalService;

    public GetAllAdditionalsQueryHandler(IAdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    public async Task<IEnumerable<AdditionalResponseViewModel>> Handle(GetAllAdditionalsQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _additionalService.GetAllAdditionals();
        return result;
    }
}