using JwtStore.Core.AccountContext;

namespace JwtStore.UseCases.Users.Contracts;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken);

    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);
}
