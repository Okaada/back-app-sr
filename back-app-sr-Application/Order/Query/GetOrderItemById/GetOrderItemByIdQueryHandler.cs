using back_app_sr_Application.Order.Service.Interface;
using back_app_sr_Application.Order.ViewModel;
using MediatR;

namespace back_app_sr_Application.Order.Query.GetOrderItemById;

public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItemResponseViewModel>
{
    private readonly IOrderItemService _orderItemService;

    public GetOrderItemByIdQueryHandler(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    public async Task<OrderItemResponseViewModel> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemService.GetOrderItemById(request.Id);
        
        if (orderItem == null)
            return new OrderItemResponseViewModel();
        
        return orderItem;
    }
}