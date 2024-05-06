namespace Mulier.Infrastructure;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mulier.Infrastructure.EntityFrameworkCore;
using Mulier.Infrastructure.Hangfire;
using Mulier.Infrastructure.LiteDb;
using Mulier.Infrastructure.MassTransit;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddHangfire(configuration);
        services.AddLiteDb(configuration);
        services.AddEntityFrameworkCore(configuration);
        services.AddMassTransit(configuration);

        return services;
    }

    public static void UseInfrastructure(this IApplicationBuilder app)
        => app.UseHangfire();
}
