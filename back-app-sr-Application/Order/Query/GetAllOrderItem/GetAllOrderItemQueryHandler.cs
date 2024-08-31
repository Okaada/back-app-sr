using back_app_sr_Application.Order.Service.Interface;
using back_app_sr_Application.Order.ViewModel;
using MediatR;

namespace back_app_sr_Application.Order.Query.GetAllOrderItem;

public class GetAllOrderItemQueryHandler : IRequestHandler<GetAllOrderItemsQuery, IEnumerable<OrderItemResponseViewModel>>
{
    private readonly IOrderItemService _orderItemService;

    public GetAllOrderItemQueryHandler(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }
    
    public async Task<IEnumerable<OrderItemResponseViewModel>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        var orderItems = await _orderItemService.GetAllOrderItems();
        return orderItems;
    }
}