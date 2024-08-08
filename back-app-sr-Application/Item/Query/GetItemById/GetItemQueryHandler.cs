using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Query.GetItemById;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemViewModel>
{
    private readonly IItemService _itemservice;

    public GetItemQueryHandler(IItemService itemservice)
    {
        _itemservice = itemservice;
    }
    
    public async Task<ItemViewModel> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var result = await _itemservice.GetItemById(request.ItemId);
        return result;
    }
}