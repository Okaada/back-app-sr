using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Query.GetActiveItemById;

public class GetActiveItemByIdQueryHandler : IRequestHandler<GetActiveItemByIdQuery, GetItemViewModel>
{
    private readonly IItemService _itemservice;
    
    public GetActiveItemByIdQueryHandler(IItemService itemservice)
    {
        _itemservice = itemservice;
    }
    
    public async Task<GetItemViewModel> Handle(GetActiveItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemservice.GetActiveItemById(request.ItemId);

        if (item == null || !item.Active)
            throw new Exception();
        
        return item;
    }
}