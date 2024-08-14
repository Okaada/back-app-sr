using AutoMapper;
using back_app_sr_Application.Additional.Command.UpdateAdditional;
using back_app_sr_Application.Additional.ViewModel;
using back_app_sr.Domain.Models;

namespace back_app_sr_Application.Additional.Mappings;

public class AdditionalViewModelMapping : Profile
{
    public AdditionalViewModelMapping()
    {
        CreateMap<AdditionalModel, AdditionalViewModel>()
            .ForMember(dest => dest.AdditionalId,
                opt => opt.MapFrom(src => src.AdditionalId))
            .ReverseMap();
        CreateMap<AdditionalModel, CreateAdditionalViewModel>();
        CreateMap<AdditionalModel, DeleteAdditionalViewModel>();
        CreateMap<AdditionalModel, UpdateAdditionalViewModel>();
    }
}