using back_app_sr_Application.Order.ViewModel;
using MediatR;

namespace back_app_sr_Application.Order.Query.GetAllOrderItem;

public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItemResponseViewModel>>
{
}