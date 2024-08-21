using back_app_sr_Application.Item.ViewModel;
using back_app_sr.Domain.Models;

namespace back_app_sr_Application.Item.Service.Interface;

public interface IItemService
{
    Task<CreateItemViewModel> CreateItem(string name, decimal value, string description);
    Task<IEnumerable<ItemResponseViewModel>> GetAllItems();
    Task<ItemResponseViewModel> GetItemById(int itemId);
    Task<ItemResponseViewModel> UpdateItem(int id, string name, decimal value, string description, bool isActive);
}