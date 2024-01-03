using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Query.GetAllItems;

public class GetAllItemsQuery : IRequest<IEnumerable<ItemViewModel>>
{
    
}