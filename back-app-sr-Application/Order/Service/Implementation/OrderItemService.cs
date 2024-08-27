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

    public OrderItemService(IOrderItemRepository orderItemRepository, IUnitOfWork uow, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<OrderItemResponseViewModel> CreateOrderItem(Guid tabId, int itemId, int quantity)
    {
        var newOrder = new OrderItemsTabModel(tabId, itemId, quantity);
        await _orderItemRepository.Add(newOrder);
        
        _uow.Commit();

        return _mapper.Map<OrderItemResponseViewModel>(newOrder);
    }
}