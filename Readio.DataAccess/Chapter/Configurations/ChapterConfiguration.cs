

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readio.Model.Chapter.Entity;

namespace Readio.DataAccess.Chapter.Configurations;

public class ChapterConfiguration : IEntityTypeConfiguration<ChapterEntity>
{
    public void Configure(EntityTypeBuilder<ChapterEntity> builder)
    {

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title).IsRequired().HasMaxLength(255);
        builder.Property(c => c.Content).IsRequired();

        // many to one
        builder.HasOne(c => c.Book)
            .WithMany()
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(b => b.Book).AutoInclude();
    }

   
}
