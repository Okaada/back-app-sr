using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Query.GetAllActiveItems;

public class GetAllActiveItemsQueryHandler : IRequestHandler<GetAllActiveItemsQuery, IEnumerable<GetItemViewModel>>
{
    private readonly IItemService _itemservice;
    
    public GetAllActiveItemsQueryHandler(IItemService itemService)
    {
        _itemservice = itemService;
    }
    
    public async Task<IEnumerable<GetItemViewModel>> Handle(GetAllActiveItemsQuery request, CancellationToken cancellationToken)
    {
        var allItems = await _itemservice.GetAllActiveItems();
        var activeItems = allItems.Where(item => item.Active);
        return activeItems;
    }
}