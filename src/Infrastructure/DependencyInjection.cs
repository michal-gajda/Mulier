namespace Mulier.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mulier.Infrastructure.LiteDB;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddLiteDB(configuration);

        return services;
    }
}
