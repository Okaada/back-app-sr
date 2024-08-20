using AutoMapper;
using back_app_sr_Application.User.Mappings;
using back_app_sr_Application.User.Service.Implementation;
using back_app_sr.Domain.Models.User;
using back_app_sr.Domain.Options;
using back_app_sr.Infra.Repository.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;

namespace back_app_sr.Tests.Services.User;

public class UserTests
{
    private readonly Mock<IUserRepository> _userRepository = new();
    private readonly Mock<IUnitOfWork> _uowMock = new();
    private IMapper _mapper;
    private IOptions<JwtSettings> jwtOptions;

    public UserTests()
    {
        jwtOptions = Options.Create(new JwtSettings
        {
            Audience = "some",
            Issuer = "some",
            Secret = "87403211f51603fe1a6cf6c19c5de4cc38a5a5681064aa5d0a3c1a1cce75a167"
        });
    }

    [Test]
    public async Task Create_User_Should_Be_Successful()
    {
        _userRepository.Setup(x => x.GetUserByEmail(It.IsAny<string>()))
            .ReturnsAsync(new UserModel(It.IsAny<Guid>(), string.Empty, string.Empty, string.Empty, string.Empty));

        _userRepository.Setup(x => x.Add(It.IsAny<UserModel>())).Verifiable();

        _uowMock.Setup(x => x.Commit()).Verifiable();
        
        var myProfile = new UserMappings();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        _mapper = new Mapper(configuration);

        var service = new UserService(_userRepository.Object, _uowMock.Object, jwtOptions, _mapper);

        var result = await service.CreateUser("string", "123321", "string@email.com", "TestRole");
        result.Email.Should().Be("string@email.com");
        result.Role.Should().Be("TestRole");
        _userRepository.Verify(x => x.Add(It.IsAny<UserModel>()), Times.Once);
        _uowMock.Verify(x => x.Commit(), Times.Once);
    }
    
    [Test]
    public Task Create_User_Should_Be_Failed()
    {

        _userRepository.Setup(x => x.GetUserByEmail(It.IsAny<string>()))
            .ReturnsAsync(new UserModel(It.IsAny<Guid>(), "string", It.IsAny<string>(), It.IsAny<string>(), "string@email.com"));
        _userRepository.Setup(x => x.Add(It.IsAny<UserModel>())).Verifiable();
        _uowMock.Setup(x => x.Commit()).Verifiable();
        
        var myProfile = new UserMappings();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));    
        _mapper = new Mapper(configuration);

        var service = new UserService(_userRepository.Object, _uowMock.Object, jwtOptions, _mapper);

        var exception =  Assert.ThrowsAsync<Exception>(() => 
            service.CreateUser("New User", "password123", "string@email.com", "UserRole"));

        exception.Message.Should().Be("Email já utilizado");
        
        _userRepository.Verify(x => x.Add(It.IsAny<UserModel>()), Times.Never);
        _uowMock.Verify(x => x.Commit(), Times.Never);
        return Task.CompletedTask;
    }
    
    [Test]
    public async Task Get_AllUser_Should_Return_Data()
    {
        _userRepository.Setup(x => x.GetAll()).ReturnsAsync(GetAllUser());
        
        var myProfile = new UserMappings();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        _mapper = new Mapper(configuration);

        var service = new UserService(_userRepository.Object, _uowMock.Object, jwtOptions, _mapper);
        var result = await service.GetAllUsers();
        var userResponseViewModels = result.ToList();
            
        userResponseViewModels.Should().NotBeEmpty();
        userResponseViewModels.Should().NotBeNull();
        userResponseViewModels.Count.Should().Be(4);
    }

    private IEnumerable<UserModel> GetAllUser()
    {
        return new List<UserModel>()
        {
            new(Guid.NewGuid(), "1", "1", "1", "email1@gmail.com"),
            new(Guid.NewGuid(), "2", "2", "2", "email2@gmail.com"),
            new(Guid.NewGuid(), "3", "3", "3", "email3@gmail.com"),
            new(Guid.NewGuid(), "4", "4", "4", "email4@gmail.com"),
        };
    }
}