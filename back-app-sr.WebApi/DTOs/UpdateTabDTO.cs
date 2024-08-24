using Newtonsoft.Json;

namespace back_app_sr.WebApi.DTOs;

public class UpdateTabDTO
{
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
    [JsonProperty("table_number")] public int TableNumber { get; set; } = 0;
    [JsonProperty("status")] public string Status { get; set; } = string.Empty;
}