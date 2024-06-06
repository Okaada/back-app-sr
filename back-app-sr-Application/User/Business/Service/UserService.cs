using System.Security.Cryptography;
using back_app_sr_Application.User.Business.Interface;
using back_app_sr_Application.User.DTO;
using back_app_sr.Domain.Models;
using back_app_sr.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace back_app_sr_Application.User.Business.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;
    
    public UserService(IUserRepository userRepository, IUnitOfWork uow)
    {
        _userRepository = userRepository;
        _uow = uow;
    }
    
    public UserModel CreateUser(string name, string password, string email)
    {
        //hash password

        var user = new UserModel(Guid.NewGuid(), name, UserModel.HashPassword(password), "user", email);
        
        _userRepository.Add(user);
        _uow.Commit();
        return user;
    }

    public async Task<UserDTO> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if(user.VerifyPassword(password))
            return new UserDTO(user.Email, user.Role);

        throw new Exception("Invalid password");
    }
    
    
    
}