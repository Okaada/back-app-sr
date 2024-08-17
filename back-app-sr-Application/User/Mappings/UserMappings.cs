using AutoMapper;
using back_app_sr_Application.User.ViewModel;
using back_app_sr.Domain.Models.User;

namespace back_app_sr_Application.User.Mappings;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<UserModel, UserCreationViewModel>();
        CreateMap<UserModel, UserResponseViewModel>();
    }
}