using AutoMapper;
using back_app_sr_Application.Additional.ViewModel;
using back_app_sr.Domain.Models.Items;

namespace back_app_sr_Application.Additional.Mappings;

public class AdditionalViewModelMapping : Profile
{
    public AdditionalViewModelMapping()
    {
        CreateMap<AdditionalModel, CreateAdditionalViewModel>();
        CreateMap<AdditionalModel, GetAdditionalViewModel>()
            .ForMember(dest => dest.AdditionalId, opt => opt.MapFrom(src => src.Id));
        CreateMap<AdditionalModel, UpdateAdditionalViewModel>();
        CreateMap<AdditionalModel, DeleteAdditionalViewModel>();
    }
}