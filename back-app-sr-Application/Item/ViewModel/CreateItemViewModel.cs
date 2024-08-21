using Newtonsoft.Json;

namespace back_app_sr_Application.Item.ViewModel;

public class CreateItemViewModel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("value")]
    public decimal Value { get; set; }
    [JsonProperty("description")] 
    public string Description { get; set; }
}