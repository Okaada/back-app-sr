using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Query.GetAllItems;

public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemResponseViewModel>>
{
    private readonly IItemService _itemservice;
    
    public GetAllItemsQueryHandler(IItemService itemService)
    {
        _itemservice = itemService;
    }
    
    public async Task<IEnumerable<ItemResponseViewModel>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemservice.GetAllItems();
        return items;
    }
}