using JwtStore.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace JwtStore.Api.Options;

public class SecretsOptionsSetup : IConfigureOptions<SecretsOptions>
{
    private const string Secrets = nameof(Secrets);
    private readonly IConfiguration _configuration;

    public SecretsOptionsSetup(IConfiguration configuration)
        => _configuration = configuration;

    public void Configure(SecretsOptions options)
        => _configuration.GetSection(Secrets)
                         .Bind(options);
}
