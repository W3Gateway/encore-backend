using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class PermissionMap : EntityTypeConfiguration<Permission>
    {
        protected override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnType("varchar(20)")
                .IsRequired();
        }
    }
}
