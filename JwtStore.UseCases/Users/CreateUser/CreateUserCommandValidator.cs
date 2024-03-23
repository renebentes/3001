using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.UseCases.Users.CreateUser;

public static class CreateUserCommandValidator
{
    public static Contract<Notification> Ensure(CreateUserCommand command)
        => new Contract<Notification>()
        .Requires()
        .IsLowerThan(command.Name.Length, 160, nameof(command.Name))
        .IsGreaterThan(command.Name.Length, 3, nameof(command.Name))
        .IsLowerThan(command.Password.Length, 40, nameof(command.Password))
        .IsGreaterThan(command.Password.Length, 8, nameof(command.Password))
        .IsEmail(command.Email, nameof(command.Email));
}
