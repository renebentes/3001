using FluentAssertions;
using JwtStore.UseCases.Users.Contracts;
using JwtStore.UseCases.Users.CreateUser;

namespace JwtStore.UseCases.UnitTests.Users.CreateUser;

public class CreateUserCommandHandlerTests
{
    private readonly CancellationTokenSource _tokenSource = new();
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

    [Fact]
    public async Task CreateUserCommandHandlerShouldReturnInvalidResultWhenGivenInvalidEmail()
    {
        var command = new CreateUserCommand("user", "user@test", "12345678");
        var commandHandler = new CreateUserCommandHandler(_userRepository);
        var result = await commandHandler.Handle(command, _tokenSource.Token);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public async Task CreateUserCommandHandlerShouldReturnInvalidResultWhenGivenInvalidName()
    {
        var command = new CreateUserCommand("", "user@test.com", "12345678");
        var commandHandler = new CreateUserCommandHandler(_userRepository);
        var result = await commandHandler.Handle(command, _tokenSource.Token);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public async Task CreateUserCommandHandlerShouldReturnInvalidResultWhenGivenInvalidPassword()
    {
        var command = new CreateUserCommand("user", "user@test.com", "1234567");
        var commandHandler = new CreateUserCommandHandler(_userRepository);
        var result = await commandHandler.Handle(command, _tokenSource.Token);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public async Task CreateUserCommandHandlerShouldReturnSuccessResult()
    {
        var command = new CreateUserCommand("user", "user@test.com", "123456789");
        var commandHandler = new CreateUserCommandHandler(_userRepository);
        var result = await commandHandler.Handle(command, _tokenSource.Token);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeOfType<CreateUserResponse>();
    }
}
