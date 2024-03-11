using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.UseCases.Users.CreateUser;

public static class CreateUserCommandValidation
{
    public static Contract<Notification> Ensure(CreateUserCommand command)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(command.Name.Length, 160, "Name", "O nome deve conter menos que 160 caracteres")
            .IsGreaterThan(command.Name.Length, 3, "Name", "O nome deve conter mais que 3 caracteres")
            .IsLowerThan(command.Password.Length, 40, "Password", "A senha deve conter menos que 40 caracteres")
            .IsGreaterThan(command.Password.Length, 8, "Password", "A senha deve conter mais que 8 caracteres")
            .IsEmail(command.Email, "Email", "E-mail inválido");
}
