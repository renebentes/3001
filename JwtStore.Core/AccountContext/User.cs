namespace JwtStore.Core.AccountContext;

public class User : Entity
{
    public User(string name, Email email, Password password, string image = "")
    {
        Email = email;
        Image = image;
        Name = name;
        Password = password;
    }

    public User(string name, string email, string? password = null, string image = "")
        : this(name, new Email(email), new Password(password), image)
    { }

    private User()
    { }

    public Email Email { get; set; } = default!;

    public string Image { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public Password Password { get; set; } = default!;

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
