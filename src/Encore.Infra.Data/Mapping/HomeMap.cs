using Encore.Domain.Homes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class HomeMap : EntityTypeConfiguration<Home>
    {
        protected override void Configure(EntityTypeBuilder<Home> builder)
        {
            builder.Property(h => h.TypeProperty)
                .HasColumnType("varchar(30)");

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

            builder.Property(h => h.ContactNumber)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(h => h.MedicalRecordNumber)
                .HasColumnType("varchar(50)");

            builder.Property(h => h.HouseholdIncome)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(h => h.NumberMembers)
                .HasColumnType("numeric(3)")
                .IsRequired();

            builder.HasOne(h => h.Microregion)
                .WithMany(p => p.Homes)
                .HasForeignKey(h => h.MicroregionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
