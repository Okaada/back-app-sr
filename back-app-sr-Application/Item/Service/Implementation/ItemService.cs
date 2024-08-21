using AutoMapper;
using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using back_app_sr.Domain.Models.Items;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr_Application.Item.Service.Implementation;

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
    
    public async Task<CreateItemViewModel> CreateItem(string name, decimal value, string description)
    {
        var newItem = new ItemModel(name, value, description);
        await _itemRepository.Add(newItem);
        
        _uow.Commit();

        return _mapper.Map<CreateItemViewModel>(newItem);
    }

    public async Task<IEnumerable<ItemResponseViewModel>> GetAllItems()
    {
        return _mapper.Map<IEnumerable<ItemResponseViewModel>>(await _itemRepository.GetAll());
    }

    public async Task<ItemResponseViewModel> GetItemById(int itemId)
    {
        var item = await _itemRepository.GetById(itemId);

        if (item == null)
            return new ItemResponseViewModel();
            
        return _mapper.Map<ItemResponseViewModel>(item);
    }

    public async Task<ItemResponseViewModel> UpdateItem(int itemId, string name, decimal value, string description, bool isActive)
    {
        var item = await _itemRepository.GetById(itemId);
        if (item == null)
            return new ItemResponseViewModel();

        item.Name = name;
        item.Value = value;
        item.Description = description;
        item.IsActive = isActive;
        
        _itemRepository.Update(item);
        _uow.Commit();

        return _mapper.Map<ItemResponseViewModel>(item);
    }
}