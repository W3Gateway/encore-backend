using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class OtherQuestionMap : EntityTypeConfiguration<OtherQuestion>
    {
        protected override void Configure(EntityTypeBuilder<OtherQuestion> builder)
        {
            builder.Property(v => v.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.HasOne(p => p.Question)
                .WithMany(p => p.OtherQuestions)
                .HasForeignKey(fk => fk.QuestionId);
        }
    }
}
