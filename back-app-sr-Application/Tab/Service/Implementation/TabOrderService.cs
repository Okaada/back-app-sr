using back_app_sr_Application.Tab.DTO;
using back_app_sr_Application.Tab.Service.Interface;
using back_app_sr_Application.Tab.ViewModel;
using back_app_sr.Domain.Models;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr_Application.Tab.Service.Implementation;

public class TabOrderService : ITabOrderService
{
    private readonly ITabOrderRepository _tabOrderRepository;
    private readonly IUnitOfWork _uow;

    public TabOrderService(ITabOrderRepository tabOrderRepository, IUnitOfWork uow)
    {
        _tabOrderRepository = tabOrderRepository;
        _uow = uow;
    }

    public async Task<TabOrderViewModel> AddOrder(Guid tabId, OrderDTO order)
    {
        var newOrder = new OrderModel(order.ItemId, order.AdditionId, order.Note, order.Quantity, tabId);
        await _tabOrderRepository.Add(newOrder);
        _uow.Commit();
        return new TabOrderViewModel();
    }
}