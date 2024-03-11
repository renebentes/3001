namespace JwtStore.UseCases.Users.CreateUser;

public record CreateUserCommand(string Name, string Email, string Password)
    : ICommand<Result<CreateUserResponse>>;
