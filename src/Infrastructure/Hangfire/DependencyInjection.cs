namespace Mulier.Infrastructure.Hangfire;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class DependencyInjection
{
    public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static void UseHangfire(this IApplicationBuilder _)
    {
    }
}
