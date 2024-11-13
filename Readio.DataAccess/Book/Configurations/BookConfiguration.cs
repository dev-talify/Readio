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

        //navigation property ilişkileri eklenecek
    }
}
