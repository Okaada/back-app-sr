using back_app_sr_Application.Item.ViewModel;
using back_app_sr.Domain.Models;
namespace back_app_sr_Application.Item.Service.Interface;

public interface IItemService
{
    Task<string> CreateItem(string name, decimal value);
    Task<IEnumerable<ItemViewModel>> GetAllItems();
    Task<ItemViewModel> GetItemById(int itemId);
}