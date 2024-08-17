using AutoMapper;
using back_app_sr_Application.Additional.Command.UpdateAdditional;
using back_app_sr_Application.Additional.ViewModel;
using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Items;

namespace back_app_sr_Application.Additional.Mappings;

public class AdditionalViewModelMapping : Profile
{
    public AdditionalViewModelMapping()
    {
        CreateMap<AdditionalModel, GetAdditionalViewModel>();
        CreateMap<AdditionalModel, CreateAdditionalViewModel>();
        CreateMap<AdditionalModel, DeleteAdditionalViewModel>();
        CreateMap<AdditionalModel, UpdateAdditionalViewModel>();
    }
}