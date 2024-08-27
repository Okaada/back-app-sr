using back_app_sr_Application.Order.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Order.Command.CreateOrderItem;

public class CreateOrderItemCommand : IRequest<OrderItemResponseViewModel>
{
    [JsonProperty("tab_id")]
    public Guid TabId { get; set; }
    [JsonProperty("item_id")]
    public int ItemId { get; set; }
    [JsonProperty("quantity")]
    public int Quantity { get; set; }
}