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

            builder.OwnsOne(h => h.Address, a =>
            {
                a.Property(x => x.Number)
                    .HasColumnType("numeric(4,3)")
                    .HasColumnName("Number")
                    .IsRequired();

                a.Property(x => x.State)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("State")
                    .IsRequired();

                a.Property(x => x.City)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("City")
                    .IsRequired();

                a.Property(x => x.Neighborhood)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("Neighborhood")
                    .IsRequired();

                a.Property(x => x.Street)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("Street")
                    .IsRequired();

                a.Property(x => x.StreetComplement)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("StreetComplement");

                a.Property(x => x.Landmark)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("Landmark");

                a.Property(x => x.State)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("State")
                    .IsRequired();

                a.Property(x => x.PostalCode)
                    .HasColumnType("varchar(8)")
                    .HasColumnName("PostalCode")
                    .IsRequired();
            });

            builder.HasOne(h => h.Accountable)
                .WithOne(u => u.HealthCenter)
                .HasForeignKey<HealthCenter>(h => h.AccountableId)
                .IsRequired();
        }
    }
}
