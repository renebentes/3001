using JwtStore.Core.SharedContext.Primitives;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtStore.Infrastructure.Data.Repositories;

/// <summary>
/// A <see cref="RepositoryBase{TEntity}" can be used to query and save instance of <typeparamref name="TEntity"/>.
/// </summary>
/// <typeparam name="TEntity">The type of entity being operated on by this repository</typeparam>
/// <param name="dbContext">The instance of <see cref="DbContext"/> that represents the database.</param>
internal abstract class RepositoryBase<TEntity>(DbContext dbContext)
    where TEntity : Entity
{
    protected DbContext DbContext { get; private set; } = dbContext;

    /// <summary>
    /// Adds an entity in the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

    /// <summary>
    /// Returns a boolean that represents whether any entity satisfy the condition or not.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains true if the source sequence contains any elements; otherwise, false.
    /// </returns>
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await DbContext.Set<TEntity>().AnyAsync(predicate, cancellationToken);

    // <summary>
    /// Persists changes to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await DbContext.SaveChangesAsync(cancellationToken);
}
