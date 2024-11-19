

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Readio.Model.Author.Entity;
using Readio.Model.Book.Entity;
using Readio.Model.Example.Entity;
using Readio.Model.Genre.Entity;
using Readio.Model.Member.Entity;
using Readio.Model.User.Entity;
using System.Reflection;
using Readio.Model.User.Token;
using Readio.Model.Comment.Entity;

namespace Readio.DataAccess.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<UserEntity, IdentityRole, string>(options)
{
    /*public DbSet<ExampleEntity> Examples { get; set; }*/ // entity tablosunun oluşturulması 
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<MemberEntity> Members { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}
