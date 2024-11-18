

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readio.Model.Genre.Entity;

namespace Readio.DataAccess.Genre.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
{

    public void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired() // boş olamaz.
               .HasMaxLength(50);
    }
}
