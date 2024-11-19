
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readio.Model.Comment.Entity;

namespace Readio.DataAccess.Comment.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Content).IsRequired().HasMaxLength(1000);

        // many to one
        builder.HasOne(c => c.Book)
            .WithMany()
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);

       // many to one
        builder.HasOne(c => c.Member) 
            .WithMany() 
            .HasForeignKey(c => c.MemberId) 
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(b => b.Book).AutoInclude();
        builder.Navigation(b => b.Member).AutoInclude();
    }
}
