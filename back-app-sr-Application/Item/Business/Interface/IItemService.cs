using back_app_sr.Domain.Models;
namespace back_app_sr_Application.Item.Business.Interface;

public interface IItemService
{
    ItemModel CreateItem(string name, decimal value);
}