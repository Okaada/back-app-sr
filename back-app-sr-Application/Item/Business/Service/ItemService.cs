using back_app_sr_Application.Item.Business.Interface;
using back_app_sr.Domain.Models;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr_Application.Item.Business.Service;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _uow;
    
    public ItemService(IItemRepository itemRepository, IUnitOfWork uow)
    {
        _itemRepository = itemRepository;
        _uow = uow;
    }
    
    public ItemModel CreateItem(string name, decimal value)
    {
        var item = new ItemModel(name, value);

        _itemRepository.Add(item);
        _uow.Commit();
        
        return item;
    }
}