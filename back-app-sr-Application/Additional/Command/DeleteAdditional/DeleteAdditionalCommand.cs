using back_app_sr_Application.Additional.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Additional.Command.DeleteAdditional;

public class DeleteAdditionalCommand : IRequest<DeleteAdditionalViewModel>
{
    [JsonProperty("additional_id")]
    public int AdditionalId { get; set; }
}