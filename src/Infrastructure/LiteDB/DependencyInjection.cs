namespace Mulier.Infrastructure.LiteDB;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mulier.Domain.Interfaces;
using Mulier.Infrastructure.LiteDB.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddLiteDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IIngredientRepository, IngredientRepository>();

        return services;
    }
}
