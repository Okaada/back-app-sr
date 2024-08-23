using back_app_sr_Application.Tab.DTO;
using back_app_sr_Application.Tab.ViewModel;

namespace back_app_sr_Application.Tab.Service.Interface;

public interface ITabService
{
    Task<TabCreationViewModel> CreateTab(int tableNumber, string name);
    Task<IEnumerable<TabViewModel>> GetAllTabs();
    Task<TabViewModel> GetTabById(Guid tabId);
    Task<UpdateTabViewModel> UpdateTab(Guid guid, string name, string status, int table);
}   