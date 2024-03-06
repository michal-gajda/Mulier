namespace Mulier.Infrastructure.LiteDb;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mulier.Domain.Interfaces;
using Mulier.Infrastructure.LiteDb.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddLiteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IIngredientRepository, IngredientRepository>();

        return services;
    }
}
