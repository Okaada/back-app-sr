using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using back_app_sr_Application.User.DTO;
using back_app_sr_Application.User.Service.Interface;
using back_app_sr_Application.User.ViewModel;
using back_app_sr.Domain.Models.User;
using back_app_sr.Domain.Options;
using back_app_sr.Infra.Repository.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace back_app_sr_Application.User.Service.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;
    private readonly JwtSettings _jwtSettings;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork uow, IOptions<JwtSettings> appSettings,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _uow = uow;
        _mapper = mapper;
        _jwtSettings = appSettings.Value;
    }

    public async Task<UserCreationViewModel> CreateUser(string name, string password, string email, string role)
    {
        var existentUser = await _userRepository.GetUserByEmail(email);
        if (!string.IsNullOrEmpty(existentUser.Email))
            throw new Exception("Email já utilizado");

        var user = new UserModel(Guid.NewGuid(), name, UserModel.HashPassword(password), role, email);

        await _userRepository.Add(user);
        _uow.Commit();

        return _mapper.Map<UserCreationViewModel>(user);
    }

    public async Task<UserLoginResponseDTO> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (!user.VerifyPassword(password)) return new UserLoginResponseDTO(string.Empty);

        var token = await GenerateJwtToken(user);
        return new UserLoginResponseDTO(token);
    }

    public async Task<UserResponseViewModel?> GetById(Guid id)
    {
        var result = await _userRepository.GetById(id);
        return _mapper.Map<UserResponseViewModel>(result);
    }

    public async Task<IEnumerable<UserResponseViewModel?>> GetAllUsers()
    {
        var users = await _userRepository.GetAll();
        return _mapper.Map<IEnumerable<UserResponseViewModel>>(users);
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await _userRepository.GetById(id);
        if (user == null) return false;
        _userRepository.Delete(user);
        _uow.Commit();
        return true;

    }

    public async Task<UserUpdateViewModel> UpdateUser(Guid id, string name, string password, string email, string role)
    {
        var user = await _userRepository.GetById(id);
        if (user != null)
        {
            if (!string.IsNullOrEmpty(name))
                user.UpdateName(name);
            if (!string.IsNullOrEmpty(password))
                user.UpdatePassword(password);
            if (!string.IsNullOrEmpty(email))
                user.UpdateEmail(email);
            if (!string.IsNullOrEmpty(role))
                user.UpdateRole(role);
        }

        return _mapper.Map<UserUpdateViewModel>(user);
    }

    private async Task<string> GenerateJwtToken(UserModel user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.UserId.ToString()),
                    new Claim("role", user.Role),
                    new Claim("email", user.Email)
                }),
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return tokenHandler.WriteToken(token);
    }
}