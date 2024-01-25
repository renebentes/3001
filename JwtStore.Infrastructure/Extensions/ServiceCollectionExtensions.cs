using JwtStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JwtStore.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    private const string DefaultConnection = nameof(DefaultConnection);

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options
            => options.UseSqlServer(configuration.GetConnectionString(DefaultConnection))
        );

        return services;
    }
}
