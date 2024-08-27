using back_app_sr.Domain.Models.Tab;
using back_app_sr.Infra.Context;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr.Infra.Repository.Service;

public class OrderItemRepository : Repository<OrderItemsTabModel>, IOrderItemRepository
{
    public OrderItemRepository(ApplicationContext context) : base(context)
    {
    }
}