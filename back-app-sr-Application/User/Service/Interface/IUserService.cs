using back_app_sr_Application.User.DTO;
using back_app_sr_Application.User.ViewModel;
using back_app_sr.Domain.Models.User;

namespace back_app_sr_Application.User.Service.Interface;

public interface IUserService
{
    Task<UserCreationViewModel> CreateUser(string name, string password, string email, string role);
    Task<UserLoginResponseDTO> Login(string email, string password);
    Task<UserResponseViewModel?> GetById(Guid id);
    Task<IEnumerable<UserResponseViewModel?>> GetAllUsers();
    Task<bool> DeleteUser(Guid id);
    Task<UserUpdateViewModel> UpdateUser(Guid id, string name, string password, string email, string role);
}