using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.ViewModel;

public class TabCreationViewModel
{
    [JsonProperty("table_number")] public int TableNumber { get; set; }
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("total")] public decimal Total { get; set; } = 0;
}