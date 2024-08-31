using AutoMapper;
using back_app_sr_Application.Order.Service.Interface;
using back_app_sr_Application.Order.ViewModel;
using back_app_sr.Domain.Models.Tab;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr_Application.Order.Service.Implementation;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly ITabRepository _tabRepository;
    private readonly IItemRepository _itemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository, IUnitOfWork uow, IMapper mapper, ITabRepository tabRepository, IItemRepository itemRepository)
    {
        _orderItemRepository = orderItemRepository;
        _uow = uow;
        _mapper = mapper;
        _tabRepository = tabRepository;
        _itemRepository = itemRepository;
    }

    public async Task<OrderItemResponseViewModel> CreateOrderItem(Guid tabId, int itemId, int quantity)
    {
        var tabExist = await _tabRepository.GetById(tabId);
        if (tabExist is null)
            throw new Exception($"Não foi encontrada comanda com o ID {tabId}");

        var itemExist = await _itemRepository.GetById(itemId);
        if (itemExist is null)
            throw new Exception($"Não foi encontrado item com o ID {itemId}");
        
        var newOrder = new OrderItemsTabModel(tabId, itemId, quantity);
        await _orderItemRepository.Add(newOrder);
        
        _uow.Commit();

        return _mapper.Map<OrderItemResponseViewModel>(newOrder);
    }

    public async Task<IEnumerable<OrderItemResponseViewModel>> GetAllOrderItems()
    { 
        return _mapper.Map<IEnumerable<OrderItemResponseViewModel>>(await _orderItemRepository.GetAll());
    }

    public async Task<OrderItemResponseViewModel> GetOrderItemById(Guid id)
    {
        var orderItem = await _orderItemRepository.GetById(id);

        if (orderItem == null)
            return new OrderItemResponseViewModel();

        return _mapper.Map<OrderItemResponseViewModel>(orderItem);
    }
}