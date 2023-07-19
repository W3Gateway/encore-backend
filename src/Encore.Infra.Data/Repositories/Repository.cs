using Encore.Domain.Core.Intefaces;
using Encore.Domain.Core.Models;
using Encore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Encore.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly ApplicationContext Context;
        protected readonly DbSet<TEntity> DbSet;
        private bool _disposed;

        protected Repository(ApplicationContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async ValueTask<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => 
            await Include().SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async ValueTask<List<TEntity>> GetAsync(CancellationToken cancellationToken = default) => 
            await Include().ToListAsync(cancellationToken);

        public async ValueTask<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) => 
            await Include().Where(predicate).ToListAsync(cancellationToken);

        public ValueTask<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.AddedDate = DateTime.Now;
            var entityEntry = DbSet.Add(entity);
            return new ValueTask<TEntity>(entityEntry.Entity);
        }

        public ValueTask<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.ModifiedDate = DateTime.Now;
            var entityEntry = DbSet.Update(entity);
            return new ValueTask<TEntity>(entityEntry.Entity);
        }

        public ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.Ativo = false;
            entity.ModifiedDate = DateTime.Now;
            return new ValueTask();
        }

        public virtual IQueryable<TEntity> Include() => DbSet;

        public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath) => DbSet.Include(navigationPropertyPath);

        protected virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            Context.SaveChangesAsync(cancellationToken);

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                Context.Dispose();

            _disposed = true;
        }

        #endregion IDisposable
    }
}
