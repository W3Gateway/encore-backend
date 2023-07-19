using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class MicroregionMap : EntityTypeConfiguration<Microregion>
    {
        protected override void Configure(EntityTypeBuilder<Microregion> builder)
        {
            builder.Property(m => m.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasOne(m => m.HealthCenter)
                .WithMany(hc => hc.Microregions)
                .HasForeignKey(m => m.HealthCenterId)
                .IsRequired();
        }
    }
}
