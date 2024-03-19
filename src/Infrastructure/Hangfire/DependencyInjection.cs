namespace Mulier.Infrastructure.Hangfire;

using global::Hangfire;
using global::Hangfire.LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class DependencyInjection
{
    public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(cfg => cfg
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseLiteDbStorage());

        services.AddHangfireServer();

        return services;
    }

    public static void UseHangfire(this IApplicationBuilder app)
    {
        app.UseHangfireDashboard();
    }
}
