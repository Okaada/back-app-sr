using Newtonsoft.Json;

namespace back_app_sr.WebApi.DTOs.Additional;

public class UpdateAdditionalDTO
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("value")]
    public decimal Value { get; set; }
}