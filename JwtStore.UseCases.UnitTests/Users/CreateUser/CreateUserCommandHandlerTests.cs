using FluentAssertions;
using JwtStore.UseCases.Users.Contracts;
using JwtStore.UseCases.Users.CreateUser;

namespace JwtStore.UseCases.UnitTests.Users.CreateUser;

public class CreateUserCommandHandlerTests
{
    private readonly CancellationTokenSource _tokenSource = new();
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

    [Fact]
    public async Task CreateUserCommandHandleShouldReturnSuccessResult()
    {
        var command = new CreateUserCommand("user", "user@test.com", "123456789");
        var commandHandler = new CreateUserCommandHandler(_userRepository);
        var result = await commandHandler.Handle(command, _tokenSource.Token);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeOfType<CreateUserResponse>();
    }
}
