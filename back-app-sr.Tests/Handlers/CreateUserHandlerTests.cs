using back_app_sr_Application.User.Command.CreateUser;
using back_app_sr_Application.User.Service.Interface;
using back_app_sr_Application.User.ViewModel;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace back_app_sr.Tests.Handlers;

public class CreateUserHandlerTests
{
    private readonly Mock<IUserService> _service = new();


    [TestCase("ravel", "an2itTXXr.R2.b6", "user", "ravel@gmail.com")]
    [TestCase("jow", "an2itTXXr.R2.b6", "admin", "jow@gmail.com")]
    [TestCase("user1", "an2itTXXr.R2.b6", "admin", "user1@gmail.com")]
    [TestCase("admin", "an2itTXXr.R2.b6", "admin", "admin@gmail.com")]
    [TestCase("blabla", "an2itTXXr.R2.b6", "user", "blabla@gmail.com")]
    public async Task Create_User_Command_Handler_Should_Return_Success(string name, string password, string role,
        string email)
    {
        _service.Setup(x => x.CreateUser(name, password, email, role))
            .ReturnsAsync(new UserCreationViewModel
            {
                Email = email,
                Role = role
            });

        var command = new CreateUserCommand()
        {
            Username = name,
            Email = email,
            Password = password,
            Role = role
        };

        var commandHandler = new CreateUserCommandHandler(_service.Object);
        var result = await commandHandler.Handle(command, new CancellationToken());

        result.Email.Should().NotBeEmpty();
        result.Email.Should().Be(email);
    }

    [TestCase("ravel", "an2itTXXr.R2.b6", "user", "ravel.com")]
    [TestCase("ravel", "an2itTXXr.R2.b6", "user", "ravelokada@")]
    [TestCase("ravel", "an2itTXXr.R2.b6", "user", "123@.br")]
    public Task Create_User_Command_Handler_With_InvalidEmails_Should_Fail(string name, string password, string role,
        string email)
    {
        var command = new CreateUserCommand()
        {
            Username = name,
            Email = email,
            Password = password,
            Role = role
        };
        
        var commandHandler = new CreateUserCommandHandler(_service.Object);
        var exception =  Assert.ThrowsAsync<ValidationException>(() => 
            commandHandler.Handle(command, new CancellationToken()));

        exception.Errors.Should().HaveCount(1);
        exception.Errors.First().ToString().Should().Be("O E-mail deve estar no formato válido (email@email.com)");
        
        return Task.CompletedTask;
    }
}