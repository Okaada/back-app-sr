using back_app_sr_Application.Tab.DTO;
using back_app_sr_Application.Tab.ViewModel;

namespace back_app_sr_Application.Tab.Service.Interface;

public interface ITabOrderService
{
    Task<TabOrderViewModel> AddOrder(Guid tabId, OrderDTO order);

}