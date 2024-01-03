using AutoMapper;
using back_app_sr_Application.Tab.ViewModel;
using back_app_sr.Domain.Models;

namespace back_app_sr_Application.Tab.Mappings;

public class TabCreationViewModelMapping : Profile
{
    public TabCreationViewModelMapping()
    {
        CreateMap<TabModel, TabCreationViewModel>()
            .ForMember(dest => dest.TableNumber, opt =>
                opt.MapFrom(src => src.TableNumber))
            .ReverseMap();
    }
}