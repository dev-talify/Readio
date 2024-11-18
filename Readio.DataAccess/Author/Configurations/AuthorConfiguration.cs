

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readio.Model.Author.Entity;

namespace Readio.DataAccess.Author.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {

        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.Name)
               .IsRequired()                  
               .HasMaxLength(100);            

        builder.Property(a => a.Bio)
               .HasMaxLength(500);

        // one to many
        builder.HasMany(a => a.Books)
               .WithOne(b => b.Author)
               .HasForeignKey(b => b.AuthorEntityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(a => a.Books).AutoInclude();

    }
}
