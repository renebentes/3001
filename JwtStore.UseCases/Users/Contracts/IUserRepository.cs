using JwtStore.Core.AccountContext;

namespace JwtStore.UseCases.Users.Contracts;

/// <summary>
/// Represents the <see cref="User"/> repository interface
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Adds an <see cref="User"/> in the database.
    /// </summary>
    /// <param name="user">The <see cref="User"/> to persist.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if the specified <see cref="Email"/> is unique.
    /// </summary>
    /// <param name="email">The <see cref="Email"/></param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>True if the specified email is unique, false otherwise.</returns>
    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
