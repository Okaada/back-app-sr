using AutoMapper;
using back_app_sr_Application.Tab.Service.Interface;
using back_app_sr_Application.Tab.ViewModel;
using back_app_sr.Domain.Models.Tab;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr_Application.Tab.Service.Implementation;

public class TabService : ITabService
{
    private readonly ITabRepository _tabRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    
    public TabService(ITabRepository tabRepository, IUnitOfWork uow, IMapper mapper)
    {
        _tabRepository = tabRepository;
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<TabCreationViewModel> CreateTab(int tableNumber)
    {
        var newTab = new TabModel(tableNumber);
        await _tabRepository.Add(newTab);
        
        _uow.Commit();

        return _mapper.Map<TabCreationViewModel>(newTab);
    }

    public async Task<IEnumerable<TabViewModel>> GetAllTabs()
    {
        return _mapper.Map<IEnumerable<TabViewModel>>(await _tabRepository.GetAll());
    }

    public async Task<TabViewModel> GetTabById(Guid tabId)
    {
        return _mapper.Map<TabViewModel>(await _tabRepository.GetById(tabId));
    }
}