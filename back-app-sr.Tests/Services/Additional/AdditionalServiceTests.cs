﻿using AutoMapper;
using back_app_sr_Application.Additional.Mappings;
using back_app_sr_Application.Additional.Service.Implementation;
using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Items;
using back_app_sr.Infra.Repository.Interfaces;
using FluentAssertions;
using Moq;

namespace back_app_sr.Tests.Services.Additional;

public class AdditionalServiceTests
{
    private readonly Mock<IAdditionalRepository> _additionalRepositoryMock;
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<IAdditionalService> _service;
    private IMapper _mapper;

    public AdditionalServiceTests()
    {
        _additionalRepositoryMock = new Mock<IAdditionalRepository>();
        _uowMock = new Mock<IUnitOfWork>();
        _service = new Mock<IAdditionalService>();
    }

    #region CreateAdditional Tests

    [Test]
    public async Task CreateAdditional_WhenCalled_ReturnsCreateAdditionalViewModel()
    {
        var myProfile = new AdditionalViewModelMapping();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        _mapper = new Mapper(configuration);
        
        // Arrange
        var additional = new AdditionalModel("Teste", (decimal)10.35);
        _additionalRepositoryMock.Setup(x => x.Add(It.IsAny<AdditionalModel>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        _uowMock.Setup(x => x.Commit()).Verifiable();

        var additionalService = new AdditionalService(_additionalRepositoryMock.Object, _uowMock.Object, _mapper);
        
        // Act
        var result =
            await additionalService.CreateAdditional(additional.Name, additional.Value);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<CreateAdditionalViewModel>();
        result.Name.Should().Be(additional.Name);
        result.Value.Should().Be(additional.Value);
        _additionalRepositoryMock.Verify(x => x.Add(It.Is<AdditionalModel>(a => 
            a.Name == additional.Name && a.Value == additional.Value)), Times.Once);
        _uowMock.Verify(x => x.Commit(), Times.Once);
    }

    #endregion

    #region GetAdditionalById Tests

    [Test]
    public async Task GetAdditionalById_WhenCalled_ReturnsAdditionalViewModel()
    {
        // Arrange
        var additional = new AdditionalModel("Teste", (decimal)10.35);
        _additionalRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
            .ReturnsAsync(additional)
            .Verifiable();

        var additionalService = new AdditionalService(_additionalRepositoryMock.Object, _uowMock.Object, _mapper);

        // Act
        var result = await additionalService.GetAdditionalById(1);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AdditionalResponseViewModel>();
        result.Name.Should().Be(additional.Name);
        result.Value.Should().Be(additional.Value);
        _additionalRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
    }

    #endregion

    #region GetAllAdditionals Test

    [Test]
    public async Task GetAllAdditionals_WhenCalled_ReturnsListOfAdditionals()
    {
        var myProfile = new AdditionalViewModelMapping();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        _mapper = new Mapper(configuration);
    
        // Arrange
        var additionalList = new List<AdditionalModel>
        {
            new AdditionalModel("Primeiro teste", (decimal)10.50),
            new AdditionalModel("Segundo teste", (decimal)20.50)
        };
    
        _additionalRepositoryMock.Setup(x => x.GetAll())
            .ReturnsAsync(additionalList)
            .Verifiable();

        var additionalService = new AdditionalService(_additionalRepositoryMock.Object, _uowMock.Object, _mapper);
    
        // Act
        var result = await additionalService.GetAllAdditionals();
        var resultList = result.ToList();
    
        // Assert
        resultList.Should().NotBeNull();
        resultList.Should().BeOfType<List<AdditionalResponseViewModel>>();
        resultList.Count.Should().Be(additionalList.Count);

        for (int i = 0; i < additionalList.Count; i++)
        {
            resultList[i].Name.Should().Be(additionalList[i].Name);
            resultList[i].Value.Should().Be(additionalList[i].Value);
        }

        _additionalRepositoryMock.Verify(x => x.GetAll(), Times.Once);
    }

    #endregion
}