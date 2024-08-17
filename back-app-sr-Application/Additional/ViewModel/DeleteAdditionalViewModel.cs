using Newtonsoft.Json;

namespace back_app_sr_Application.Additional.ViewModel;

public class DeleteAdditionalViewModel
{
    [JsonProperty("additional_id")]
    public int AdditionalId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("value")]
    public decimal Value { get; set; }
}