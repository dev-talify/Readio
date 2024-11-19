

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readio.Model.Member.Entity;

namespace Readio.DataAccess.Member.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<MemberEntity>
{
    public void Configure(EntityTypeBuilder<MemberEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.FirstName)
               .HasMaxLength(50);

        builder.Property(a => a.LastName)
               .HasMaxLength(50);

        builder.Property(a => a.ProfilePicture)
               .HasMaxLength(255);

        //one to many
        builder.HasMany(m => m.Comments) 
           .WithOne(c => c.Member) 
           .HasForeignKey(c => c.MemberId) 
           .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(c => c.Comments).AutoInclude();
    }
}
