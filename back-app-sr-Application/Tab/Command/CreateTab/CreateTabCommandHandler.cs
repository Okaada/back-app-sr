using back_app_sr_Application.Tab.Business.Interface;
using back_app_sr_Application.Tab.ViewModel;
using MediatR;

namespace back_app_sr_Application.Tab.Command.CreateTab;

public class CreateTabCommandHandler : IRequestHandler<CreateTabCommand, TabCreationViewModel>
{
    private readonly ITabService _tabService;
    
    public CreateTabCommandHandler(ITabService service)
    {
        _tabService = service;
    }

    public async Task<TabCreationViewModel> Handle(CreateTabCommand request, CancellationToken cancellationToken)
    {
        var result = await _tabService.CreateTab(request.TableNumer, request.TabType, request.Delivery);
        return result;
    }
}