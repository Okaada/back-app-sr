using back_app_sr_Application.Tab.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Tab.Command.UpdateTab;

public class UpdateTabCommand : IRequest<UpdateTabViewModel>
{

    public Guid Id { get; set; }
    public int TableNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
