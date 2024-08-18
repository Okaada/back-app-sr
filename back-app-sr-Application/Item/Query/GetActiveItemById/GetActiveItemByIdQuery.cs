using back_app_sr_Application.Item.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Item.Query.GetActiveItemById;

public class GetActiveItemByIdQuery : IRequest<GetItemViewModel>
{
    [JsonProperty("item_id")]
    public int ItemId { get; set; }

    public bool Active { get; set; }
}