

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Readio.Service.Authentication.Abstracts;
using Readio.Service.Authentication.Concretes;
using Readio.Service.Author.Abstracts;
using Readio.Service.Author.Concretes;
using Readio.Service.Author.Rules;
using Readio.Service.Book.Abstracts;
using Readio.Service.Book.Concretes;
using Readio.Service.Book.Rules;
using Readio.Service.Example.Abstract;
using Readio.Service.Example.Concretes;
using Readio.Service.Example.Rules;
using Readio.Service.Genre.Abstracts;
using Readio.Service.Genre.Concretes;
using Readio.Service.Genre.Rules;
using Readio.Service.Token.Abstracts;
using Readio.Service.Token.Concretes;
using Readio.Service.User.Abstracts;
using Readio.Service.User.Concretes;
using Readio.Service.User.Rules;
using System.Reflection;

namespace Readio.Service.Extensions;

public static class ServiceDependencies
{
    // service DI kayıtları
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IExampleService,ExampleService>();
        services.AddScoped<IAuthorService,AuthorService>();
        services.AddScoped<IBookService,BookService>();
        services.AddScoped<IGenreService, GenreService>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();

        services.AddScoped<AuthorBusinessRules>();
        services.AddScoped<BookBusinessRules>();
        services.AddScoped<GenreBusinessRules>();
        services.AddScoped<ExampleBusinessRules>();
        services.AddScoped<UserBusinessRules>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
