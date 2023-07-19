using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class AgentMap : EntityTypeConfiguration<Agent>
    {
        protected override void Configure(EntityTypeBuilder<Agent> builder)
        {
            //    builder.Property(v => v.Name)
            //        .HasColumnType("varchar(200)")
            //        .IsRequired();

            //    builder.Property(c => c.Email)
            //        .HasColumnType("varchar(50)")
            //        .IsRequired();

            //    builder.Property(c => c.PasswordHash)
            //        .HasColumnType("nvarchar(256)")
            //        .IsRequired();

        }
    }
}
