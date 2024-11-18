

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Readio.Model.Author.Entity;
using Readio.Model.Book.Entity;
using Readio.Model.Example.Entity;
using Readio.Model.User.Entity;
using Readio.Model.User.Token;
using System.Reflection;

namespace Readio.DataAccess.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<UserEntity,IdentityRole,string>(options) 
{
    /*public DbSet<ExampleEntity> Examples { get; set; }*/ // entity tablosunun oluşturulması 
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}
