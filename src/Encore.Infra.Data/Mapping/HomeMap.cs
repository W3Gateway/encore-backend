using Encore.Domain.Models;
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

            builder.Property(h => h.ContactNumber)
                .HasColumnType("varchar(15)");

            builder.Property(h => h.HomeContact)
                .HasColumnType("varchar(15)");

            builder.Property(h => h.MedicalRecordNumber)
                .HasColumnType("varchar(50)");

            builder.Property(h => h.HouseholdIncome)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(h => h.NumberMembers)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(h => h.LocationType)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(h => h.RuralProductionArea)
                .HasColumnType("varchar(60)");

            builder.Property(h => h.Situation)
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(h => h.TypeAccess)
               .HasColumnType("varchar(60)")
               .IsRequired();

            builder.Property(h => h.TypeDomicile)
               .HasColumnType("varchar(60)")
               .IsRequired();

            builder.Property(h => h.PredominantMaterial)
                .HasColumnType("varchar(60)");

            builder.Property(h => h.NumberRooms)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(h => h.WaterSupply)
               .HasColumnType("varchar(60)")
               .IsRequired();

            builder.Property(h => h.WaterConsumption)
                .HasColumnType("varchar(60)");

            builder.Property(h => h.SanitaryDrainage)
               .HasColumnType("varchar(60)")
               .IsRequired();

            builder.Property(h => h.GarbageDestination)
               .HasColumnType("varchar(60)")
               .IsRequired();

            builder.Property(h => h.Electricity)
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(h => h.Animals)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(h => h.AmountAnimals)
               .HasColumnType("int")
               .IsRequired();

            builder.HasOne(h => h.Microregion)
                .WithMany(p => p.Homes)
                .HasForeignKey(h => h.MicroregionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Address)
                .WithMany(p => p.Homes)
                .HasForeignKey(h => h.AddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
