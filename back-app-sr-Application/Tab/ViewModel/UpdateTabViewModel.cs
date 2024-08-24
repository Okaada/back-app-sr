using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.ViewModel;

public class UpdateTabViewModel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("table_number")]
    public int TableNumber { get; set; }
}