namespace Mulier.Infrastructure.LiteDb;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mulier.Domain.Interfaces;
using Mulier.Infrastructure.LiteDb.Services;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddLiteDb(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection(LiteDbOptions.SectionName).Get<LiteDbOptions>();
        options ??= new LiteDbOptions();
        services.AddSingleton(options);

        services.AddSingleton<IIngredientRepository, IngredientRepository>();
        services.AddSingleton<IToDoRepository, ToDoRepository>();

        return services;
    }
}
