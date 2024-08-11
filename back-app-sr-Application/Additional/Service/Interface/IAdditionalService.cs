using back_app_sr_Application.Additional.ViewModel;

namespace back_app_sr_Application.Additional.Service.Interface;

public interface IAdditionalService
{
    Task<string> CreateAdditional(string name, decimal value);
    Task<IEnumerable<AdditionalViewModel>> GetAllAdditionals();
    Task<AdditionalViewModel> GetAdditionalById(int additionalId);
    Task<bool> DeleteAdditional(int additionalId);
    Task<bool> UpdateAdditional(int additionalId, string name, decimal value);
}