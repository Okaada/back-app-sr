using back_app_sr_Application.Tab.DTO;
using back_app_sr_Application.Tab.ViewModel;

namespace back_app_sr_Application.Tab.Service.Interface;

public interface ITabService
{
    Task<TabCreationViewModel> CreateTab(int tableNumber, string tabType, DeliveryDTO? delivery);
    Task<IEnumerable<TabViewModel>> GetAllTabs();
    Task<TabViewModel> GetTabById(Guid tabId);
}   