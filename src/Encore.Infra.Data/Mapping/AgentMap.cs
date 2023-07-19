using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class AgentMap : EntityTypeConfiguration<Agent>
    {
        protected override void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasOne(a => a.User)
                .WithMany(u => u.Agents)
                .HasForeignKey(a => a.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.HealthCenter)
                .WithMany(u => u.Agents)
                .HasForeignKey(a => a.HealthCenterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Microregion)
                .WithMany(u => u.Agents)
                .HasForeignKey(a => a.MicroregionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
