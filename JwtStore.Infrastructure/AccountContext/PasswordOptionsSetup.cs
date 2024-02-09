using JwtStore.Core.AccountContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JwtStore.Infrastructure.AccountContext;

public class PasswordOptionsSetup(IConfiguration configuration)
    : IConfigureOptions<PasswordOptions>
{
    public void Configure(PasswordOptions options)
        => configuration.GetSection(PasswordOptions.Password)
            .Bind(options);
}
