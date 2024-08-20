using Newtonsoft.Json;

namespace back_app_sr_Application.Item.ViewModel;

public class ItemViewModel
{
    [JsonProperty("item_id")]
    public int ItemId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
    [JsonProperty("value")]
    public decimal Value { get; set; }
}