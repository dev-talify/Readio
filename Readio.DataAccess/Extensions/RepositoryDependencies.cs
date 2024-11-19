

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Readio.DataAccess.Author.Abstracts;
using Readio.DataAccess.Author.Concretes;
using Readio.DataAccess.Book.Abstracts;
using Readio.DataAccess.Book.Concretes;
using Readio.DataAccess.Comment.Abstracts;
using Readio.DataAccess.Comment.Concretes;
using Readio.DataAccess.Contexts;
using Readio.DataAccess.Example.Abstracts;
using Readio.DataAccess.Example.Concretes;
using Readio.DataAccess.Genre.Abstracts;
using Readio.DataAccess.Genre.Concretes;
using Readio.DataAccess.Interceptors;
using Readio.DataAccess.Member.Abstracts;
using Readio.DataAccess.Member.Concretes;
using Readio.DataAccess.Options;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.DataAccess.UnitOfWorks.Concretes;
using Readio.Model.User.Entity;

namespace Readio.DataAccess.Extensions;

public static class RepositoryDependencies
{
    //DI kayıtları
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionStrings = configuration.GetSection
            (ConnectionStringOption.Key).Get<ConnectionStringOption>();

            options.UseSqlServer(connectionStrings!.SqlCon, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
            });

            options.AddInterceptors(new AuditDbContextInterceptor());
        });


        services.AddScoped<IExampleRepository,ExampleRepository>();
        services.AddScoped<IAuthorRepository,AuthorRepository>();
        services.AddScoped<IBookRepository,BookRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<ICommentRepository,CommentRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
