using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Item.Command;

public class ItemCommand : IRequest<string>
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
    [JsonProperty("value")]
    public decimal Value { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("categoryItemId")]
    public int CategoryItemId { get; set; }
}