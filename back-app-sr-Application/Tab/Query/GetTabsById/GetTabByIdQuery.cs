using back_app_sr_Application.Tab.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.Query.GetTabsById;

public class GetTabByIdQuery : IRequest<TabViewModel>
{
    [JsonProperty("tab_id")]
    public Guid TabId { get; set; }
}