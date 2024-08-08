using back_app_sr_Application.Tab.Service.Interface;
using back_app_sr_Application.Tab.ViewModel;
using MediatR;

namespace back_app_sr_Application.Tab.Query.GetAllTabs;

public class GetAllTabsQueryHandler : IRequestHandler<GetAllTabsQuery, IEnumerable<TabViewModel>>
{
    private readonly ITabService _tabService;

    public GetAllTabsQueryHandler(ITabService tabService)
    {
        _tabService = tabService;
    }
    
    public async Task<IEnumerable<TabViewModel>> Handle(GetAllTabsQuery request, CancellationToken cancellationToken)
    {
        var result = await _tabService.GetAllTabs();
        return result;
    }
}