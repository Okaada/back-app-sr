using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Command.UpdateItem;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ItemResponseViewModel>
{
    private readonly IItemService _itemService;

    public UpdateItemCommandHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<ItemResponseViewModel> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateItemValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
            throw new FluentValidation.ValidationException("Error", validation.Errors);

        var result = await _itemService.UpdateItem(request.ItemId, request.Name, request.Value, request.Description, request.IsActive);
        return result;
    }
}