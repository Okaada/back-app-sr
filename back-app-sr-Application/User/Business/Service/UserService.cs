using System.Security.Cryptography;
using back_app_sr_Application.User.Business.Interface;
using back_app_sr.Domain.Models;
using back_app_sr.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
        
        //create user
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        var user = new UserModel(name, hashed, "user", email);
        
        //save user
        _userRepository.Add(user);
        _uow.Commit();
        return user;
    }
}