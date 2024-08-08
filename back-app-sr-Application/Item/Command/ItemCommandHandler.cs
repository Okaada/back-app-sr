using back_app_sr_Application.Item.Service.Interface;
using MediatR;

namespace back_app_sr_Application.Item.Command;

public class ItemCommandHandler : IRequestHandler<ItemCommand, string>
{
    private readonly IItemService _itemService;
    
    public ItemCommandHandler(IItemService itemService)
    {
        _itemService = itemService;
    }
    
    public Task<string> Handle(ItemCommand request, CancellationToken cancellationToken)
    {

        var result = _itemService.CreateItem(request.Name, request.Value);
        return Task.FromResult("Item criado com sucesso!");
    }
}