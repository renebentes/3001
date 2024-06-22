namespace JwtStore.UseCases.Users.CreateUser;

public static class CreateUserCommandValidator
{
    public const int NameMaxLength = 160;
    public const int NameMinLength = 3;
    public const int PasswordMaxLength = 40;
    public const int PasswordMinLength = 8;

    public static Contract<Notification> Ensure(CreateUserCommand command)
        => new Contract<Notification>()
        .Requires()
        .IsLowerThan(command.Name.Length, NameMaxLength, nameof(command.Name))
        .IsGreaterThan(command.Name.Length, NameMinLength, nameof(command.Name))
        .IsLowerThan(command.Password.Length, PasswordMaxLength, nameof(command.Password))
        .IsGreaterThan(command.Password.Length, PasswordMinLength, nameof(command.Password))
        .IsEmail(command.Email, nameof(command.Email));
}
