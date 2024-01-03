using back_app_sr_Application.Tab.DTO;
using back_app_sr_Application.Tab.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.Command.CreateTab;

public class CreateTabCommand : IRequest<TabCreationViewModel>
{

    [JsonProperty("table_number")]
    public int TableNumber { get; set; }
    [JsonProperty("delivery")]
    public DeliveryDTO? Delivery { get; set; }
    [JsonProperty("tab_type")]
    public string TabType { get; set; }
}
