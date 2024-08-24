using AutoMapper;
using back_app_sr_Application.Tab.Mappings;
using back_app_sr_Application.Tab.Service.Implementation;
using back_app_sr_Application.Tab.Service.Interface;
using back_app_sr_Application.Tab.ViewModel;
using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Tab;
using back_app_sr.Infra.Repository.Interfaces;
using Moq;
using FluentAssertions;

namespace back_app_sr.Tests.Services.Tab;

public class TabServiceTests
{
    private readonly Mock<ITabRepository> _tabRepositoryMock;
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<ITabService> _service;
    
    public TabServiceTests()
    {
        _tabRepositoryMock = new Mock<ITabRepository>();
        _uowMock = new Mock<IUnitOfWork>();
        _service = new Mock<ITabService>();
    }
    
    [Test]
    public async Task CreateTab_WhenCalled_ReturnsTabCreationViewModel()
    {
        var myProfile = new TabCreationViewModelMapping();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);
        
        // Arrange
        _tabRepositoryMock.Setup(x => x.Add(It.IsAny<TabModel>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        _uowMock.Setup(x => x.Commit()).Verifiable();
        
        var tabService = new TabService(_tabRepositoryMock.Object, 
            _uowMock.Object, mapper);
        
        // Act
        var result = await tabService.CreateTab(1, "Hantaro");
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<TabCreationViewModel>();
        result.TableNumber.Should().Be(1);
        result.Name.Should().Be("Hantaro");
        result.Total.Should().Be(0);
        _tabRepositoryMock.Verify(x => x.Add(It.IsAny<TabModel>()), Times.Once);
        _uowMock.Verify(x => x.Commit(), Times.Once);
    }
    
    [Test]

    public async Task GetAllTabs_WhenCalled_Returns_ViewModel()
    {
        var myProfile = new TabViewModelMapping();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);
        
        // Arrange
        _tabRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(CreateTabs());
        
        var tabService = new TabService(_tabRepositoryMock.Object, 
            _uowMock.Object, mapper);
        
        // Act
        var result = await tabService.GetAllTabs();
        
        // Assert
        var tabViewModels = result as TabViewModel[] ?? result.ToArray();
        tabViewModels.Should().NotBeNull();
        tabViewModels.Should().BeOfType<TabViewModel[]>();
        tabViewModels.Length.Should().Be(4);
        tabViewModels.Should().NotBeEmpty();
    }

    [Test]

    public async Task GetByIdTab_WhenCalled_Returns_ViewModel()
    {
        var myProfile = new TabViewModelMapping();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);
        
        // Arrange
        _tabRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(CreateTabs().First());
        
        var tabService = new TabService(_tabRepositoryMock.Object, 
            _uowMock.Object, mapper);
        
        
        // Act
        var result = await tabService.GetTabById(It.IsAny<Guid>());
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<TabViewModel>();
        result.Total.Should().Be(0);
        result.Name.Should().Be("John");
    }
    
    [Test]

    public async Task GetByIdTab_WhenCalled_Returns_Nothing()
    {
        var myProfile = new TabViewModelMapping();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);
        
        // Arrange
        _tabRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync((TabModel?)null);
        
        var tabService = new TabService(_tabRepositoryMock.Object, 
            _uowMock.Object, mapper);
        
        
        // Act
        var result = await tabService.GetTabById(It.IsAny<Guid>());
        
        // Assert
        result.Id.Should().BeEmpty();
        result.Should().BeOfType<TabViewModel>();
        result.Total.Should().Be(0);
        result.Name.Should().Be(string.Empty);
    }
    
    
    [Test]

    public async Task UpdateTab_WhenCalled_Returns_Success()
    {
        var myProfile = new TabViewModelMapping();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);
        
        // Arrange
        _tabRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(CreateTabs().FirstOrDefault);
        
        _tabRepositoryMock.Setup(x => x.Update(It.IsAny<TabModel>())).Verifiable();
        
        var tabService = new TabService(_tabRepositoryMock.Object, 
            _uowMock.Object, mapper);
        
        
        // Act
        var result = await tabService.UpdateTab(It.IsAny<Guid>(), "Robso",
            "Aberta", It.IsAny<int>());
        
        // Assert
        result.Name.Should().NotBeEmpty();
        result.Name.Should().Be("Robso");
        result.Should().BeOfType<UpdateTabViewModel>();
        result.Status.Should().Be("Aberta");
        _tabRepositoryMock.Verify(x => x.Update(It.IsAny<TabModel>()), Times.Once);
    }
    
    private IEnumerable<TabModel> CreateTabs()
    {
        return new List<TabModel>()
        {
            new(11, "John"),
            new(12, "Doe"),
            new(12, "Carlito"),
            new(12, "Tablito")
        };
    }
}