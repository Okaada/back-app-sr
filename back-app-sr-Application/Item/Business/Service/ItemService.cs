using AutoMapper;
using back_app_sr_Application.Item.Business.Interface;
using back_app_sr_Application.Item.ViewModel;
using back_app_sr.Domain.Models;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr_Application.Item.Business.Service;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ItemService(IItemRepository itemRepository, IUnitOfWork uow, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _uow = uow;
        _mapper = mapper;
    }
    
    public ItemModel CreateItem(string name, decimal value)
    {
        var item = new ItemModel(name, value);

        _itemRepository.Add(item);
        _uow.Commit();
        
        return item;
    }
    
    public async Task<IEnumerable<ItemViewModel>> GetAllItems()
    {
        return _mapper.Map<IEnumerable<ItemViewModel>>(await _itemRepository.GetAll());
    }

    public async Task<ItemViewModel> GetItemById(int itemId)
    {
        return _mapper.Map<ItemViewModel>(await _itemRepository.GetById(itemId));
    }
}