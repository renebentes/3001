using JwtStore.Core.AccountContext.Options;

namespace JwtStore.Core.AccountContext.Common;

public static class Settings
{
    public static SecretsOptions SecretsOptions { get; set; } = new();
}
