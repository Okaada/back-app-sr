using back_app_sr_Application.Item.ViewModel;
using back_app_sr.Domain.Models;
namespace back_app_sr_Application.Item.Business.Interface;

public interface IItemService
{
    Task<string> CreateItem(string name, decimal value, string description, int categoryItemId);
    Task<IEnumerable<ItemViewModel>> GetAllItems();
    Task<ItemViewModel> GetItemById(int itemId);
}