using AutoMapper;
using back_app_sr_Application.Tab.ViewModel;
using back_app_sr.Domain.Models;

namespace back_app_sr_Application.Tab.Mappings;

public class TabViewModelMapping : Profile
{
    public TabViewModelMapping()
    {
        CreateMap<TabModel, TabViewModel>()
            .ForMember(dest => dest.TableNumber,
                opt => opt.MapFrom(src => src.TableNumber))
            .ReverseMap();
  
    }
}