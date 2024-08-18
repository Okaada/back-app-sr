using System.ComponentModel.DataAnnotations;
using back_app_sr_Application.Item.Command.CreateItem;
using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace back_app_sr_Application.Item.Command.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemViewModel>
{
    private readonly IItemService _itemService;
    
    public CreateItemCommandHandler(IItemService itemService)
    {
        _itemService = itemService;
    }
    
    public async Task<CreateItemViewModel> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateItemValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
            throw new ValidationException("Error", validation.Errors);

        var result = await _itemService.CreateItem(request.Name, request.Value, request.Description, request.Active);
        return result;
    }
}