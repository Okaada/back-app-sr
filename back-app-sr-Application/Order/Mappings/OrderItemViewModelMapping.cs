using AutoMapper;
using back_app_sr_Application.Order.ViewModel;
using back_app_sr.Domain.Models.Tab;

namespace back_app_sr_Application.Order.Mappings;

public class OrderItemViewModelMapping : Profile
{
    public OrderItemViewModelMapping()
    {
        CreateMap<OrderItemsTabModel, OrderItemResponseViewModel>();
    }
}