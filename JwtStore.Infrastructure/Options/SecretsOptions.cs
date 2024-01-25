namespace JwtStore.Infrastructure.Options;

public sealed class SecretsOptions
{
    public string ApiKey { get; init; } = string.Empty;

    public string JwtPrivateKey { get; init; } = string.Empty;

    public string PasswordSaltKey { get; init; } = string.Empty;
}
