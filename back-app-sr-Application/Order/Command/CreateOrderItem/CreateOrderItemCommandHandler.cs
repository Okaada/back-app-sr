using back_app_sr_Application.Order.Command.CreateOrderItem;
using back_app_sr_Application.Order.Service.Interface;
using back_app_sr_Application.Order.ViewModel;
using FluentValidation;
using MediatR;

namespace back_app_sr_Application.Order.Command.CreateOrderItem;

public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, OrderItemResponseViewModel>
{
    private readonly IOrderItemService _orderItemService;

    public CreateOrderItemCommandHandler(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }
    
    public async Task<OrderItemResponseViewModel> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateOrderItemValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
            throw new ValidationException("Error", validation.Errors);

        var result = await _orderItemService.CreateOrderItem(request.TabId, request.ItemId, request.Quantity);
        return result;
    }
}