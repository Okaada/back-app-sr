using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;

namespace back_app_sr_Application.Item.Command.DeleteItem;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, DeleteItemViewModel>
{
    private readonly IItemService _itemService;

    public DeleteItemCommandHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<DeleteItemViewModel> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteItemValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
            throw new FluentValidation.ValidationException("Error", validation.Errors);

        var result = await _itemService.DeleteItem(request.ItemId);

        return result;
    }
}