using Encore.Domain.Enum;
using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Encore.Infra.Data.Mapping
{
    internal class FormMap : EntityTypeConfiguration<Form>
    {
        protected override void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.Property(f => f.Slug)
                .HasConversion(new EnumToStringConverter<EFormType>());
            builder.HasIndex(f => f.Slug)
                .IsUnique();

            builder.Property(f => f.Title)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasMany(f => f.Questions)
                .WithOne(q => q.Form)
                .HasForeignKey(q => q.FormId);
        }
    }
}
