using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class AddressMap : EntityTypeConfiguration<Address>
    {
        protected override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Number)
                .HasColumnType("int")
                .HasColumnName("Number")
                .IsRequired();

            builder.Property(x => x.State)
                .HasColumnType("varchar(50)")
                .HasColumnName("State")
                .IsRequired();

            builder.Property(x => x.City)
                .HasColumnType("varchar(50)")
                .HasColumnName("City")
                .IsRequired();

            builder.Property(x => x.Neighborhood)
                .HasColumnType("varchar(50)")
                .HasColumnName("Neighborhood")
                .IsRequired();

            builder.Property(x => x.Street)
                .HasColumnType("varchar(100)")
                .HasColumnName("Street")
                .IsRequired();

            builder.Property(x => x.StreetType)
                .HasColumnType("varchar(50)")
                .HasColumnName("StreetType")
                .IsRequired();

            builder.Property(x => x.StreetComplement)
                .HasColumnType("varchar(20)")
                .HasColumnName("StreetComplement");

            builder.Property(x => x.Landmark)
                .HasColumnType("varchar(200)")
                .HasColumnName("Landmark");

            builder.Property(x => x.State)
                .HasColumnType("varchar(50)")
                .HasColumnName("State")
                .IsRequired();

            builder.Property(x => x.PostalCode)
                .HasColumnType("varchar(8)")
                .HasColumnName("PostalCode")
                .IsRequired();
        }
    }
}
