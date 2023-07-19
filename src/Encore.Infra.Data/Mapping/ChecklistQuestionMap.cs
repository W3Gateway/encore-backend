using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encore.Infra.Data.Mapping
{
    internal class ChecklistQuestionMap : EntityTypeConfiguration<ChecklistQuestion>
    {
        protected override void Configure(EntityTypeBuilder<ChecklistQuestion> builder)
        {
            //builder.Property(v => v.Name)
            //    .HasColumnType("varchar(200)")
            //    .IsRequired();

            //builder.HasOne(p => p.Question)
            //    .WithMany(p => p.ChecklistQuestions)
            //    .HasForeignKey(fk => fk.QuestionId);
        }
    }
}
