using System.Net.Http.Headers;
using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Query.GetItemById;

public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemResponseViewModel>
{
    private readonly IItemService _itemservice;
    
    public GetItemByIdQueryHandler(IItemService itemservice)
    {
        _itemservice = itemservice;
    }
    
    public async Task<ItemResponseViewModel> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemservice.GetItemById(request.ItemId);

        if (item == null)
            return new ItemResponseViewModel();
        
        return item;
    }
}