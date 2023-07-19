using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class UserPermissionMap : EntityTypeConfiguration<UserPermission>
    {
        protected override void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasOne(up => up.User)
                .WithMany(u => u.Permissions)
                .HasForeignKey(up => up.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(up => up.Permission)
                .WithMany(p => p.Users)
                .HasForeignKey(up => up.PermissionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
