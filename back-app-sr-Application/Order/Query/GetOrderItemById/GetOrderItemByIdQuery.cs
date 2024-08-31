using back_app_sr_Application.Order.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Order.Query.GetOrderItemById;

public class GetOrderItemByIdQuery : IRequest<OrderItemResponseViewModel>
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
}