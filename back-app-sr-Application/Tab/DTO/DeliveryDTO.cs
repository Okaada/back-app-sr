using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.DTO;

public class DeliveryDTO
{
    [JsonProperty("name")]
    public string Name { get; set; }= string.Empty;
    [JsonProperty("telephone")]
    public string Telephone { get; set; }= string.Empty;
    [JsonProperty("address")]
    public string Address { get; set; } = string.Empty;
}