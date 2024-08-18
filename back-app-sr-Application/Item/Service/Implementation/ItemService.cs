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
    
    public async Task<CreateItemViewModel> CreateItem(string name, decimal value, string description, bool active)
    {
        var newItem = new ItemModel(name, value, description, active);
        await _itemRepository.Add(newItem);
        
        _uow.Commit();

        return _mapper.Map<CreateItemViewModel>(newItem);
    }

    public async Task<IEnumerable<GetItemViewModel>> GetAllActiveItems()
    {
        return _mapper.Map<IEnumerable<GetItemViewModel>>(await _itemRepository.GetAll());
    }

    public async Task<GetItemViewModel> GetActiveItemById(int itemId)
    {
        return _mapper.Map<GetItemViewModel>(await _itemRepository.GetById(itemId));
    }

    public async Task<UpdateItemViewModel> UpdateItem(int itemId, string name, decimal value, string description)
    {
        var item = await _itemRepository.GetById(itemId);
        if (item == null)
            throw new Exception("Item não encontrado");

        if (item.Active != true)
            throw new Exception("Não é possível atualizar um item inativo");

        item.Name = name;
        item.Value = value;
        item.Description = description;
        
        _itemRepository.Update(item);
        _uow.Commit();

        return _mapper.Map<UpdateItemViewModel>(item);
    }

    public async Task<DeleteItemViewModel> DeleteItem(int id)
    {
        var item = await _itemRepository.GetById(id);
        if (item == null)
            throw new Exception("Item não encontrado");

        if (item.Active != true)
            throw new Exception("Não é possível excluir um item inativo");

        item.Active = false;
        
        var deleteItemViewModel = _mapper.Map<DeleteItemViewModel>(item); 
        
        _itemRepository.Update(item);
        _uow.Commit();

        return deleteItemViewModel;
    }
}