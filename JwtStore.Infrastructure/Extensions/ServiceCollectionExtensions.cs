using JwtStore.Infrastructure.Authentication;
using JwtStore.Infrastructure.Data;
using JwtStore.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtStore.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    private const string DefaultConnection = nameof(DefaultConnection);

    public static IServiceCollection AddConfigurations(this IServiceCollection services)
    {
        services.ConfigureOptions<SecretsOptionsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IOptions<JwtOptions> options)
    {
        var jwtOptions = options.Value;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.PrivateKey))
                    };
                });

        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options
            => options.UseSqlServer(configuration.GetConnectionString(DefaultConnection))
        );

        return services;
    }
}
