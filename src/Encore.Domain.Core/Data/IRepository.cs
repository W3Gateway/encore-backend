using Encore.Domain.Core.Intefaces;
using System.Linq.Expressions;

namespace Encore.Domain.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        ValueTask<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        ValueTask<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);

        ValueTask<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        ValueTask<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        IQueryable<TEntity> Include();

        IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);

    }
}
