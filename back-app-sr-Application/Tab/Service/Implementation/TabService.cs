// using AutoMapper;
// using back_app_sr_Application.Tab.DTO;
// using back_app_sr_Application.Tab.Service.Interface;
// using back_app_sr_Application.Tab.ViewModel;
// using back_app_sr.Domain.Models;
// using back_app_sr.Infra.Repository.Interfaces;
//
// namespace back_app_sr_Application.Tab.Service.Implementation;
//
// public class TabService : ITabService
// {
//     private readonly ITabRepository _tabRepository;
//     private readonly IUnitOfWork _uow;
//     private readonly IDeliveryRepository _deliveryRepository;
//     private readonly IMapper _mapper;
//     
//     public TabService(ITabRepository tabRepository, IUnitOfWork uow, IDeliveryRepository deliveryRepository, IMapper mapper)
//     {
//         _tabRepository = tabRepository;
//         _uow = uow;
//         _deliveryRepository = deliveryRepository;
//         _mapper = mapper;
//     }
//     
//     public async Task<TabCreationViewModel> CreateTab(int tableNumber, string tabType, DeliveryDTO delivery)
//     {
//         var newTab = new TabModel(tableNumber, tabType);
//         await _tabRepository.Add(newTab);
//         
//         if (string.Equals("ENTREGA", tabType, StringComparison.InvariantCultureIgnoreCase))
//         {
//             var mappedDelivery = new DeliveryModel(newTab.TabId, delivery.Name, delivery.Telephone, delivery.Address);
//             newTab.SetDelivery(mappedDelivery);
//             await _deliveryRepository.Add(mappedDelivery);
//         }
//         
//         _uow.Commit();
//
//         return _mapper.Map<TabCreationViewModel>(newTab);
//     }
//
//     public async Task<IEnumerable<TabViewModel>> GetAllTabs()
//     {
//         return _mapper.Map<IEnumerable<TabViewModel>>(await _tabRepository.GetAll());
//     }
//
//     public async Task<TabViewModel> GetTabById(Guid tabId)
//     {
//         return _mapper.Map<TabViewModel>(await _tabRepository.GetById(tabId));
//     }
// }