using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Query.GetAllActiveItems;

public class GetAllActiveItemsQuery : IRequest<IEnumerable<GetItemViewModel>>
{
}