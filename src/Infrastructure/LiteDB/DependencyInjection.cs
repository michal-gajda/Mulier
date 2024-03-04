namespace Mulier.Infrastructure.LiteDB;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddLiteDB(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
