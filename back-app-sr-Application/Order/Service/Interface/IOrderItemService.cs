using back_app_sr_Application.Order.ViewModel;

namespace back_app_sr_Application.Order.Service.Interface;

public interface IOrderItemService
{
    Task<OrderItemResponseViewModel> CreateOrderItem(Guid tabId, int itemId, int quantity);
    Task<IEnumerable<OrderItemResponseViewModel>> GetAllOrderItems();
    Task<OrderItemResponseViewModel> GetOrderItemById(Guid id);
}