namespace JwtStore.UseCases.Users.CreateUser;

public sealed record CreateUserCommand(string Name, string Email, string Password)
    : IRequest<Result<CreateUserResponse>>;
