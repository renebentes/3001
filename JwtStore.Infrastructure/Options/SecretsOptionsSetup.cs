using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JwtStore.Infrastructure.Options;

public sealed class SecretsOptionsSetup(IConfiguration configuration)
    : IConfigureOptions<SecretsOptions>
{
    private readonly IConfiguration _configuration = configuration;

    public void Configure(SecretsOptions options)
        => _configuration.GetSection(SecretsOptions.SectionName)
                         .Bind(options);
}
