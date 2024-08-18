using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace back_app_sr_Application.Item.ViewModel;

public class UpdateItemViewModel
{
    [JsonProperty("item_id")]
    public int ItemId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("value")]
    public decimal Value { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("active")]
    public bool Active { get; set; }
}