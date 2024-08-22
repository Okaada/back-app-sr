using Newtonsoft.Json;

namespace back_app_sr_Application.Additional.ViewModel;

public class DeleteAdditionalViewModel
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}