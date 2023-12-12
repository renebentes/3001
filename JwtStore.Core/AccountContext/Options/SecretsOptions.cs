namespace JwtStore.Core.AccountContext.Options;

public class SecretsOptions
{
    private const string Secrets = nameof(Secrets);

    public string PasswordSaltKey { get; set; } = string.Empty;
}
