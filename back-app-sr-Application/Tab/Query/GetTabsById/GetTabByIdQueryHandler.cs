using back_app_sr_Application.Tab.Service.Interface;
using back_app_sr_Application.Tab.ViewModel;
using MediatR;

namespace back_app_sr_Application.Tab.Query.GetTabsById;

public class GetTabByIdQueryHandler : IRequestHandler<GetTabByIdQuery, TabViewModel>
{
    private readonly ITabService _tabService;

    public GetTabByIdQueryHandler(ITabService tabService)
    {
        _tabService = tabService;
    }
    
    public async Task<TabViewModel> Handle(GetTabByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _tabService.GetTabById(request.TabId);
        return result;    
    }
}