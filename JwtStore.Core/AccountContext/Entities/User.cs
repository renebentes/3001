using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.SharedContext.Entities;

namespace JwtStore.Core.AccountContext.Entities;

public class User(string name, Email email, Password password, string image = "") : Entity
{
    public User(string name, string email, string? password = null, string image = "")
        : this(name, new Email(email), new Password(password), image)
    { }

    public Email Email { get; set; } = email;

    public string Image { get; set; } = image;

    public string Name { get; set; } = name;

    public Password Password { get; set; } = password;

    public void ChangePassword(string plainTextPassword)
    {
        var password = new Password(plainTextPassword);
        Password = password;
    }

    public void UpdateEmail(Email email)
    {
        Email = email;
    }

    public void UpdatePassword(string plainTextPassword, string code)
    {
        if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Código de restauração inválido");

        var password = new Password(plainTextPassword);
        Password = password;
    }
}
