using Newtonsoft.Json;

namespace back_app_sr_Application.Order.ViewModel;

public class OrderItemResponseViewModel
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("tab_id")]
    public Guid TabId { get; set; }
    [JsonProperty("item_id")]
    public int ItemId { get; set; }
    [JsonProperty("quantity")]
    public int Quantity { get; set; }
}