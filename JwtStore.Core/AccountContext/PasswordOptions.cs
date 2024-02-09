namespace JwtStore.Core.AccountContext;

public class PasswordOptions
{
    public const string Password = nameof(Password);

    public string SaltKey { get; init; } = string.Empty;
}
