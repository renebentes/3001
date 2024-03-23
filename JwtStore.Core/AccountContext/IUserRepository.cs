namespace JwtStore.Core.AccountContext;

public interface IUserRepository
{
    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);
}
