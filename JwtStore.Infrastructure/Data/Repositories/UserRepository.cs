using JwtStore.Core.AccountContext;
using JwtStore.UseCases.Users.Contracts;

namespace JwtStore.Infrastructure.Data.Repositories;

internal class UserRepository(AppDbContext dbContext) : RepositoryBase<User>(dbContext), IUserRepository
{
    public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken)
        => !await AnyAsync(user => user.Email == email, cancellationToken);
}
