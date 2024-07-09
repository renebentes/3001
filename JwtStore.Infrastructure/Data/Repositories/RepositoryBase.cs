using JwtStore.Core.SharedContext.Primitives;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtStore.Infrastructure.Data.Repositories;

internal abstract class RepositoryBase<TEntity>(DbContext dbContext)
    where TEntity : Entity
{
    protected DbContext DbContext { get; private set; } = dbContext;

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        => await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await DbContext.Set<TEntity>().AnyAsync(predicate, cancellationToken);
}
