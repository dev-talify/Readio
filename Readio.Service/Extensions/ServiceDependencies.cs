﻿

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Readio.Service.Author.Abstracts;
using Readio.Service.Author.Concretes;
using Readio.Service.Author.Rules;
using Readio.Service.Book.Abstracts;
using Readio.Service.Book.Concretes;
using Readio.Service.Book.Rules;
using Readio.Service.Example.Abstract;
using Readio.Service.Example.Concretes;
using Readio.Service.Example.Rules;
using System.Reflection;

namespace Readio.Service.Extensions;

public static class ServiceDependencies
{
    // service DI kayıtları
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IExampleService,ExampleService>();
        services.AddScoped<IAuthorService,AuthorService>();
        services.AddScoped<IBookService,BookService>();

        services.AddScoped<AuthorBusinessRules>();
        services.AddScoped<BookBusinessRules>();
        services.AddScoped<ExampleBusinessRules>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
