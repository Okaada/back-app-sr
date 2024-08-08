using back_app_sr_Application.Tab.Service.Interface;
using back_app_sr_Application.Tab.ViewModel;
using MediatR;

namespace back_app_sr_Application.Tab.Query.GetTabsById;

public class GetTabQueryHandler : IRequestHandler<GetTabQuery, TabViewModel>
{
    private readonly ITabService _tabService;

    public GetTabQueryHandler(ITabService tabService)
    {
        _tabService = tabService;
    }
    
    public async Task<TabViewModel> Handle(GetTabQuery request, CancellationToken cancellationToken)
    {
        var result = await _tabService.GetTabById(request.TabId);
        return result;    
    }
}