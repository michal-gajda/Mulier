namespace Mulier.Application;

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Mulier.Application.Common.Interfaces;
using Mulier.Application.Common.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

        services.AddSingleton<IIdProvider, IdProvider>();

        return services;
    }
}
