using Encore.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TEntity>
    {
        protected abstract void Configure(EntityTypeBuilder<TEntity> builder);

        void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name);
            builder.HasKey(t => t.Id);
            builder.Ignore(c => c.ClassLevelCascadeMode);
            builder.Ignore(c => c.RuleLevelCascadeMode);

            Configure(builder);
        }
    }
}
