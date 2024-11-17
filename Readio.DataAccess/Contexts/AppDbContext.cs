

using Microsoft.EntityFrameworkCore;
using Readio.Model.Author.Entity;
using Readio.Model.Book.Entity;
using Readio.Model.Example.Entity;
using Readio.Model.Genre.Entity;
using Readio.Model.Member.Entity;
using System.Reflection;

namespace Readio.DataAccess.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) 
{
    /*public DbSet<ExampleEntity> Examples { get; set; }*/ // entity tablosunun oluşturulması 
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<MemberEntity> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}
