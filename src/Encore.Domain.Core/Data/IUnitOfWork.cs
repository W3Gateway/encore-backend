using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Encore.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        IDbContextTransaction CurrentTransaction { get; }

        IExecutionStrategy CreateExecutionStrategy();

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

        Task<int> SaveAsync(CancellationToken cancellationToken = default);

        bool HasChanges();

        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
