using JwtStore.Api.Options;

namespace JwtStore.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services)
    {
        services.ConfigureOptions<SecretsOptionsSetup>();

        return services;
    }
}
