using back_app_sr_Application.Tab.ViewModel;
using MediatR;

namespace back_app_sr_Application.Tab.Query.GetAllTabs;

public class GetAllTabsQuery : IRequest<IEnumerable<TabViewModel>>
{
    
}