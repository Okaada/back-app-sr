using back_app_sr_Application.Additional.ViewModel;
using MediatR;

namespace back_app_sr_Application.Additional.Query.GetAllAdditionals;

public class GetAllAdditionalsQuery : IRequest<IEnumerable<GetAdditionalViewModel>>
{
}