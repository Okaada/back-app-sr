using back_app_sr_Application.Tab.DTO;
using back_app_sr_Application.Tab.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.Command.InsertOrderCommand;

public class InsertOrderCommand : IRequest<Unit>
{
    [JsonProperty("tab_id")]
    public Guid TabId { get; set; }
    [JsonProperty("order")]
    public IEnumerable<OrderDTO> Order { get; set; }
}