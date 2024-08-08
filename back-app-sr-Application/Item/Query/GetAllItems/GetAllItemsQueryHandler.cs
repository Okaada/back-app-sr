using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Query.GetAllItems;

public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemViewModel>>
{
    private readonly IItemService _itemservice;
    
    public GetAllItemsQueryHandler(IItemService itemService)
    {
        _itemservice = itemService;
    }
    
    public async Task<IEnumerable<ItemViewModel>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var result = await _itemservice.GetAllItems();
        return result;
    }
}