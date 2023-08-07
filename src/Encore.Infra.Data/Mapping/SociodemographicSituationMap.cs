using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class SociodemographicSituationMap : EntityTypeConfiguration<SociodemographicSituation>
    {
        protected override void Configure(EntityTypeBuilder<SociodemographicSituation> builder)
        {
            builder.Property(h => h.AttendSchool)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.LevelEducation)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.LaborMarketSituation)
                .HasColumnType("varchar(60)");

            builder.Property(h => h.Occupation)
                .HasColumnType("varchar(100)");

            builder.Property(h => h.HasTraditionalCaregiver)
                .HasColumnType("bit");

            builder.Property(h => h.IsMemberCommunityGroup)
                .HasColumnType("bit");

            builder.Property(h => h.HasPrivateHealthPlan)
                .HasColumnType("bit");

            builder.Property(h => h.IsMemberTraditionalCommunity)
                .HasColumnType("bit");

            builder.Property(h => h.TraditionalCommunity)
                .HasColumnType("varchar(100)");

            builder.Property(h => h.HasSexualOrientation)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.SexualOrientation)
                .HasColumnType("varchar(100)");

            builder.Property(h => h.HasGenderIdentity)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.GenderIdentity)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.HasDisability)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.Disability)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(a => a.Person)
                .WithMany(p => p.SociodemographicSituations)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
