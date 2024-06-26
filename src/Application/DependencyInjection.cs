namespace Mulier.Application;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Mulier.Application.Common.Behaviors;
using Mulier.Application.Common.Interfaces;
using Mulier.Application.Common.Services;
using Mulier.Application.ToDos.Interfaces;
using Mulier.Application.ToDos.Services;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);

            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

        services.AddSingleton<IIdProvider, IdProvider>();
        services.AddSingleton<IToDoProvider, ToDoProvider>();

        return services;
    }
}
