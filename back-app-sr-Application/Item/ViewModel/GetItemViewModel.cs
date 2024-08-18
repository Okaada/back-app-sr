using Newtonsoft.Json;

namespace back_app_sr_Application.Item.ViewModel;

public class GetItemViewModel
{
    [JsonProperty("item_id")]
    public int ItemId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
    [JsonProperty("value")]
    public decimal Value { get; set; }
    [JsonProperty("description")] 
    public string Description { get; set; }
    [JsonProperty("active")]
    public bool Active { get; set; }
}