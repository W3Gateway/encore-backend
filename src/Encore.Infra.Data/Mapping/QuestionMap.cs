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
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(p => p.Mandatory)
                .HasColumnType("boolean")
                .IsRequired();

            builder.HasMany(p => p.QuestionAnswers)
                .WithOne(p => p.Question)
                .HasForeignKey(b => b.QuestionId);

            builder.HasMany(p => p.ChecklistQuestions)
                .WithOne(p => p.Question)
                .HasForeignKey(b => b.QuestionId);
        }
    }
}
