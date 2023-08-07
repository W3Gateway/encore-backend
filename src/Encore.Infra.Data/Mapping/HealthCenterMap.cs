using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class HealthCenterMap : EntityTypeConfiguration<HealthCenter>
    {
        protected override void Configure(EntityTypeBuilder<HealthCenter> builder)
        {
            builder.Property(h => h.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.Cnes)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasOne(h => h.Accountable)
                .WithOne(u => u.HealthCenter)
                .HasForeignKey<HealthCenter>(h => h.AccountableId)
                .IsRequired();

            builder.HasOne(h => h.Address)
                .WithMany(a => a.HealthCenters)
                .HasForeignKey(h => h.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
