

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Readio.DataAccess.Author.Abstracts;
using Readio.DataAccess.Author.Concretes;
using Readio.DataAccess.Contexts;
using Readio.DataAccess.Example.Abstracts;
using Readio.DataAccess.Example.Concretes;
using Readio.DataAccess.Interceptors;
using Readio.DataAccess.Options;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.DataAccess.UnitOfWorks.Concretes;

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
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
