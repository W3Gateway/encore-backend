using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class PersonMap : EntityTypeConfiguration<Person>
    {
        protected override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(h => h.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.SocialName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.Nationality)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(h => h.Sex)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(h => h.SkinColor)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(h => h.Document)
                .HasColumnType("varchar(14)")
                .IsRequired();
            builder.HasIndex(h => h.Document)
                .IsUnique();

            builder.Property(h => h.DocumentType)
                .HasColumnType("varchar(50)")
                .IsRequired();
           
            builder.Property(h => h.Email)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(h => h.ContactNumber)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(h => h.SocialIdentification)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(h => h.FatherName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.MotherName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.BirthDate)
                .HasColumnType("Date")
                .IsRequired();

            builder.HasOne(a => a.Microregion)
                .WithMany(u => u.Persons)
                .HasForeignKey(a => a.MicroregionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Home)
                .WithMany(h => h.Persons)
                .HasForeignKey(p => p.HomeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.SociodemographicSituation)
                .WithMany(a => a.Persons)
                .HasForeignKey(h => h.SociodemographicSituationId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(p => p.HealthCondition)
                .WithMany(a => a.Persons)
                .HasForeignKey(h => h.HealthConditionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
