using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Additional.Command.DeleteAdditional;

public class DeleteAdditionalCommand : IRequest<bool>
{
    [JsonProperty("additional_id")]
    public int AdditionalId { get; set; }
}