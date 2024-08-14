using back_app_sr_Application.Additional.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Additional.Command.UpdateAdditional;

public class UpdateAdditionalCommand : IRequest<UpdateAdditionalViewModel>
{
    [JsonProperty("additional_id")]
    public int AdditionalId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("value")] 
    public decimal Value { get; set; } = 0;
}