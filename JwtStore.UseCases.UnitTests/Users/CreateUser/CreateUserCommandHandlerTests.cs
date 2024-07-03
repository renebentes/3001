using FluentAssertions;
using JwtStore.Core.AccountContext;
using JwtStore.UseCases.Users.Contracts;
using JwtStore.UseCases.Users.CreateUser;

namespace JwtStore.UseCases.UnitTests.Users.CreateUser;

public class CreateUserCommandHandlerTests
{
    private const string ValidEmail = "user@test.com";

    private readonly CreateUserCommand _command;
    private readonly CreateUserCommandHandler _commandHandler;
    private readonly CancellationTokenSource _tokenSource = new();
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

    public CreateUserCommandHandlerTests()
    {
        _commandHandler = new CreateUserCommandHandler(_userRepository);
        _command = new CreateUserCommand("user", ValidEmail, "123456789");
    }

    [Fact]
    public async Task CreateUserShouldReturnConflictResultWhenEmailAlreadyExists()
    {
        const string duplicatedEmail = "duplicated@test.com";
        var command = _command with { Email = duplicatedEmail };
        _userRepository.IsEmailUniqueAsync(duplicatedEmail, CancellationToken.None)
                       .Returns(false);
        var result = await _commandHandler.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Conflict);
    }

    [Fact]
    public async Task CreateUserShouldReturnInvalidResultWhenGivenInvalidEmail()
    {
        var command = _command with { Email = "user@test" };
        var result = await _commandHandler.Handle(command, _tokenSource.Token);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public async Task CreateUserShouldReturnInvalidResultWhenGivenInvalidName()
    {
        var command = _command with { Name = string.Empty };
        var result = await _commandHandler.Handle(command, _tokenSource.Token);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public async Task CreateUserShouldReturnInvalidResultWhenGivenInvalidPassword()
    {
        var command = _command with { Password = "1234567" };
        var result = await _commandHandler.Handle(command, _tokenSource.Token);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public async Task CreateUserShouldReturnSuccessResultWhenGivenValidData()
    {
        _userRepository.IsEmailUniqueAsync(Arg.Any<Email>(), Arg.Any<CancellationToken>())
                       .Returns(true);
        _userRepository.AddAsync(Arg.Any<User>(), CancellationToken.None)
                       .Returns(Task.FromResult(CreateUser()));

        var result = await _commandHandler.Handle(_command, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be(_command.Name);
    }

    private User CreateUser()
        => new(_command.Name, _command.Email);
}
