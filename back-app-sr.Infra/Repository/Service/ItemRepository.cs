using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Items;
using back_app_sr.Infra.Context;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr.Infra.Repository.Service;

public class ItemRepository : Repository<ItemModel>, IItemRepository
{
    public ItemRepository(ApplicationContext context): base(context)
    {
    }
}