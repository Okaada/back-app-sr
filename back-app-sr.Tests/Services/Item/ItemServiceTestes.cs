using AutoMapper;
using back_app_sr_Application.Item.Mappings;
using back_app_sr_Application.Item.Service.Implementation;
using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Item.ViewModel;
using back_app_sr.Domain.Models.Items;
using back_app_sr.Infra.Repository.Interfaces;
using FluentAssertions;
using Moq;

namespace back_app_sr.Tests.Services.Item;

public class ItemServiceTests
{
    private readonly Mock<IItemRepository> _itemRepositoryMock;
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<IItemService> _service;
    private IMapper _mapper;

    public ItemServiceTests()
    {
        _itemRepositoryMock = new Mock<IItemRepository>();
        _uowMock = new Mock<IUnitOfWork>();
        _service = new Mock<IItemService>();
    }

    #region CreateItem Tests

    [Test]
    public async Task CreateItem_WhenCalled_ReturnsCreateItemViewModel()
    {
        var myProfile = new ItemViewModelMapping();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        _mapper = new Mapper(configuration);
        
        // Arrange
        var item = new ItemModel("Nome", (decimal)10.35, "Descrição");
        _itemRepositoryMock.Setup(x => x.Add(It.IsAny<ItemModel>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        _uowMock.Setup(x => x.Commit()).Verifiable();

        var itemService = new ItemService(_itemRepositoryMock.Object, _uowMock.Object, _mapper);
        
        // Act
        var result =
            await itemService.CreateItem(item.Name, item.Value, item.Description);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<CreateItemViewModel>();
        result.Name.Should().Be(item.Name);
        result.Value.Should().Be(item.Value);
        result.Description.Should().Be(item.Description);
        _itemRepositoryMock.Verify(x => x.Add(It.Is<ItemModel>(a => 
            a.Name == item.Name && a.Value == item.Value && a.Description == item.Description && a.IsActive == item.IsActive)), Times.Once);
        _uowMock.Verify(x => x.Commit(), Times.Once);
    }

    #endregion

    #region GetActiveItemById Tests

    [Test]
    public async Task GetActiveItemById_WhenItemExists_ReturnsGetItemViewModel()
    {
        // Arrange
        var itemId = 1;
        var item = new ItemModel("Nome", (decimal)10.35, "Descrição");
        _itemRepositoryMock.Setup(x => x.GetById(itemId))
            .ReturnsAsync(item);
    
        var itemService = new ItemService(_itemRepositoryMock.Object, _uowMock.Object, _mapper);

        // Act
        var result = await itemService.GetItemById(itemId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ItemResponseViewModel>();
        result.Name.Should().Be(item.Name);
        result.Value.Should().Be(item.Value);
        result.Description.Should().Be(item.Description);
        result.IsActive.Should().BeTrue();
    }

    #endregion

    #region GetAllActiveItems Test

    [Test]
    public async Task GetAllActiveItems_WhenCalled_ReturnsListOfActiveItems()
    {
        // Arrange
        var itemModels = new List<ItemModel>
        {
            new ItemModel("Item1", 10.35m, "Descrição 1"),
            new ItemModel("Item2", 20.50m, "Descrição 2")
        };

        _itemRepositoryMock.Setup(x => x.GetAll())
            .ReturnsAsync(itemModels.AsEnumerable());

        var itemService = new ItemService(_itemRepositoryMock.Object, _uowMock.Object, _mapper);

        // Act
        var result = await itemService.GetAllItems();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.First().Should().BeOfType<ItemResponseViewModel>();
    }

    #endregion
}