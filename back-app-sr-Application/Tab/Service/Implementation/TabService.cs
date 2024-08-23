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
    
    public async Task<TabCreationViewModel> CreateTab(int tableNumber, string name)
    {
        var newTab = new TabModel(tableNumber, name);
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
        var result = await _tabRepository.GetById(tabId);
        return result == null ? new TabViewModel() : _mapper.Map<TabViewModel>(result);
    }

    public async Task<UpdateTabViewModel> UpdateTab(Guid guid, string name, string status, int table)
    {
        var currentTab = await _tabRepository.GetById(guid);
        if (currentTab == null)
            throw new KeyNotFoundException();
        
        currentTab.UpdateTab(name, status, table);
        _tabRepository.Update(currentTab);
        _uow.Commit();

        return _mapper.Map<UpdateTabViewModel>(currentTab);
    }
}