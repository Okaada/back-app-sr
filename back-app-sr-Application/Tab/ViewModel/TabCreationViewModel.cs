using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.ViewModel;

public class TabCreationViewModel
{
    [JsonProperty("table_number")]
    public int TableNumber { get; set; }
    [JsonProperty("tab_type")]
    public string TabType{ get; set; }
}