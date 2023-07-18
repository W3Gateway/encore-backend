using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class QuestionAnswerMap : EntityTypeConfiguration<QuestionAnswer>
    {
        protected override void Configure(EntityTypeBuilder<QuestionAnswer> builder)
        {
            builder.Property(p => p.Response)
                .HasColumnType("varchar(200)");

            builder.HasOne(p => p.Question)
                .WithMany(p => p.QuestionAnswers)
                .HasForeignKey(fk => fk.QuestionId);
        }
    }
}
