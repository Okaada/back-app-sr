using back_app_sr_Application.Additional.ViewModel;

namespace back_app_sr_Application.Additional.Service.Interface;

public interface IAdditionalService
{
    Task<CreateAdditionalViewModel> CreateAdditional(string name, decimal value);
    Task<IEnumerable<GetAdditionalViewModel>> GetAllAdditionals();
    Task<GetAdditionalViewModel> GetAdditionalById(int id);
    Task<DeleteAdditionalViewModel> DeleteAdditional(int id);
    Task<UpdateAdditionalViewModel> UpdateAdditional(int id, string name, decimal value);
}