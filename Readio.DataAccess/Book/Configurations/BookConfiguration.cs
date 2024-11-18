using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readio.Model.Book.Entity;

namespace Readio.DataAccess.Book.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
            .IsRequired()                 
            .HasMaxLength(255);           

        
        builder.Property(b => b.Description)
            .IsRequired()                
            .HasMaxLength(2000);

        builder.Property(b => b.AuthorEntityId).HasColumnName("AuthorId");

        //many to one
        builder.HasOne(b => b.Author)
               .WithMany(a => a.Books)
               .HasForeignKey(b => b.AuthorEntityId)
               .OnDelete(DeleteBehavior.Restrict);  

        //many to many
        builder.HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity(j => j.ToTable("BookGenres"));

        builder.Navigation(b => b.Author).AutoInclude();
        builder.Navigation(b => b.Genres).AutoInclude();

    }
}
