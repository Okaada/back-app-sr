using back_app_sr_Application.Additional.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Additional.Command.UpdateAdditional;

public class UpdateAdditionalCommand : IRequest<AdditionalResponseViewModel>
{
    public int AdditionalId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; } = 0;
}