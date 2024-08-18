using back_app_sr_Application.Item.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Item.Command.UpdateItem;

public class UpdateItemCommand : IRequest<UpdateItemViewModel>
{
    [JsonProperty("item_id")] 
    public int ItemId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
    [JsonProperty("value")]
    public decimal Value { get; set; } = 0;
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;
}