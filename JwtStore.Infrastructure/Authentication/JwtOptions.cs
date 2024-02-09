namespace JwtStore.Infrastructure.Authentication;

public sealed class JwtOptions
{
    public const string Jwt = nameof(Jwt);

    public string Audience { get; init; } = string.Empty;

    public string Issuer { get; init; } = string.Empty;

    public string PrivateKey { get; init; } = string.Empty;

    public int TokenExpirationInMinutes { get; init; }
}
