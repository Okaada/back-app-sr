using Newtonsoft.Json;

namespace back_app_sr.WebApi.DTOs.Item;

public class UpdateItemDTO
{
    [JsonProperty("name")] 
    public string Name { get; set; } = string.Empty;
    [JsonProperty("value")]
    public decimal Value { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;
    [JsonProperty("is_active")]
    public bool IsActive { get; set; }
}