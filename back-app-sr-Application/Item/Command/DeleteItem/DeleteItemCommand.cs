using back_app_sr_Application.Item.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Item.Command.DeleteItem;

public class DeleteItemCommand : IRequest<DeleteItemViewModel>
{
    [JsonProperty("item_id")]
    public int ItemId { get; set; }
}