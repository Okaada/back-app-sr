using back_app_sr_Application.Item.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Item.Command.CreateItem;

public class CreateItemCommand : IRequest<CreateItemViewModel>
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
    [JsonProperty("value")]
    public decimal Value { get; set; } = 0;
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;
    [JsonProperty("active")]
    public bool Active { get; set; } = true;
}