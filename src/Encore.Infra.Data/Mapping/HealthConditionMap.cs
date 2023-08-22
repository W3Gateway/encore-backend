using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class HealthConditionMap : EntityTypeConfiguration<HealthCondition>
    {
        protected override void Configure(EntityTypeBuilder<HealthCondition> builder)
        {
            builder.Property(h => h.WeightCondition)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(h => h.IsSmoker)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.UseAlcohol)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.UsesOtherDrugs)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.HasHypertension)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.HasDiabetes)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.HadStroke)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.HadHeartAttack)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.HasHeartDisease)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.HeartDisease)
                .HasColumnType("varchar(100)");

            builder.Property(h => h.HasRespiratoryDisease)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.RespiratoryDisease)
                .HasColumnType("varchar(100)");

            builder.Property(h => h.HasTuberculosis)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.HadKidneyProblem)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.KidneyProblem)
                .HasColumnType("varchar(100)");

            builder.Property(h => h.HasLeprosy)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.HadCancer)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.RecentlyHospitalization)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(h => h.CauseHospitalization)
                .HasColumnType("varchar(100)");

            builder.Property(h => h.DiagnoseMentalHealthProblem)
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(h => h.IsBedridden)
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(h => h.IsDomiciled)
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(h => h.IntegrativePractices)
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(h => h.UseMedicinalPlants)
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(h => h.MedicinalPlants)
                .HasColumnType("varchar(100)");

            builder.Property(h => h.OtherHealthConditions)
                .HasColumnType("varchar(250)");

            builder.Property(h => h.StreetSituation)
               .HasColumnType("bit")
               .IsRequired();
        }
    }
}
