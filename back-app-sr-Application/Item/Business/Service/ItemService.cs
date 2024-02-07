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
    private IItemService _itemServiceImplementation;

    public ItemService(IItemRepository itemRepository, IUnitOfWork uow, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<string> CreateItem(string name, decimal value, string description, int categoryItemId)
    {
        var item = new ItemModel(name, value, description, categoryItemId);

        _itemRepository.Add(item);
        _uow.Commit();
        
        return $"Item criado com sucesso. Item: '{item.Name}' , Valor: R$'{item.Value}', Descrição: '{item.Description}'";
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