namespace JwtStore.Infrastructure.Options;

public sealed class SecretsOptions
{
    public const string SectionName = "Secrets";

    public string ApiKey { get; init; } = string.Empty;

    public string PasswordSaltKey { get; init; } = string.Empty;
}
