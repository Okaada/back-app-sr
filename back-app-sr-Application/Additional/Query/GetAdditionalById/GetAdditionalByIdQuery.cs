using back_app_sr_Application.Additional.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Additional.Query.GetAdditionalById;

public class GetAdditionalByIdQuery : IRequest<GetAdditionalViewModel>
{
    [JsonProperty("additional_id")]
    public int AdditionalId { get; set; }
}