using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readio.Model.User.Entity;

namespace Readio.DataAccess.User.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
        builder.Property(x=> x.Email).IsRequired().HasMaxLength(100);
        //
    }
}
