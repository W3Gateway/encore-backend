using Encore.Domain.Enum;
using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class QuestionMap : EntityTypeConfiguration<Question>
    {
        protected override void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(v => v.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(p => p.ResponseType)
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(p => p.Mandatory)
                .HasColumnType("bit")
                .IsRequired();

            builder.HasMany(p => p.Answers)
                .WithOne(p => p.Question)
                .HasForeignKey(b => b.QuestionId);

            builder.HasMany(p => p.OtherQuestions)
                .WithOne(p => p.Question)
                .HasForeignKey(b => b.QuestionId);

        }
    }
}
