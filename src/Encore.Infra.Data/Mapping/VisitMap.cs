using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class VisitMap : EntityTypeConfiguration<Visit>
    {
        protected override void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.HasOne(a => a.Agent)
                .WithMany(u => u.Visits)
                .HasForeignKey(a => a.AgentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Person)
                .WithMany(u => u.Visits)
                .HasForeignKey(a => a.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Home)
                .WithMany(u => u.Visits)
                .HasForeignKey(a => a.HomeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Microregion)
                .WithMany(u => u.Visits)
                .HasForeignKey(a => a.MicroregionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
