using Microsoft.AspNetCore.Builder;
using Mulier.Infrastructure.Hangfire;

namespace Mulier.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mulier.Infrastructure.LiteDb;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddLiteDb(configuration);

        return services;
    }

    public static void UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseHangfire();
    }
}
