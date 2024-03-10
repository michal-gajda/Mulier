namespace Mulier.Application;

using Microsoft.Extensions.DependencyInjection;
using Mulier.Application.Common.Interfaces;
using Mulier.Application.Common.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddSingleton<IIdProvider, IdProvider>();

        return services;
    }
}
