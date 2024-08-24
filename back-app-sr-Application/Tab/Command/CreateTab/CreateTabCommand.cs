using back_app_sr_Application.Tab.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.Command.CreateTab;

public class CreateTabCommand : IRequest<TabCreationViewModel>
{

    [JsonProperty("table_number")] public int TableNumber { get; set; }
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
}
