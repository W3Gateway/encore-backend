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
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Person)
                .WithMany(u => u.Visits)
                .HasForeignKey(a => a.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
