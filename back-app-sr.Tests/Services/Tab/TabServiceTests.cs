using AutoMapper;
using back_app_sr_Application.Tab.Business.Interface;
using back_app_sr_Application.Tab.Business.Service;
using back_app_sr_Application.Tab.Mappings;
using back_app_sr_Application.Tab.ViewModel;
using back_app_sr.Domain.Models;
using back_app_sr.Infra.Repository.Interfaces;
using Moq;
using FluentAssertions;

namespace back_app_sr.Tests.Services.Tab;

public class TabServiceTests
{
    private readonly Mock<ITabRepository> _tabRepositoryMock;
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<ITabService> _service;
    private readonly Mock<IDeliveryRepository> _deliveryRepositoryMock;
    
    public TabServiceTests()
    {
        _tabRepositoryMock = new Mock<ITabRepository>();
        _uowMock = new Mock<IUnitOfWork>();
        _service = new Mock<ITabService>();
        _deliveryRepositoryMock = new Mock<IDeliveryRepository>();
    }
    
    [Test]
    public async Task CreateTab_WhenCalled_ReturnsTabCreationViewModel()
    {
        var myProfile = new TabCreationViewModelMapping();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);
        
        // Arrange
        var tab = new TabModel(0, "Retirada");
        _tabRepositoryMock.Setup(x => x.Add(It.IsAny<TabModel>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        _uowMock.Setup(x => x.Commit()).Verifiable();
        
        var tabService = new TabService(_tabRepositoryMock.Object, 
            _uowMock.Object, _deliveryRepositoryMock.Object, mapper);
        
        // Act
        var result = await tabService.CreateTab(tab.TableNumber, tab.TabType, null);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<TabCreationViewModel>();
        result.TableNumber.Should().Be(tab.TableNumber);
        result.TabType.Should().Be(tab.TabType);
        _tabRepositoryMock.Verify(x => x.Add(It.IsAny<TabModel>()), Times.Once);
        _uowMock.Verify(x => x.Commit(), Times.Once);
    }
}