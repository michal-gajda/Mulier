namespace Mulier.Application.FunctionalTests;

using Mulier.Infrastructure;

public sealed class MulierBootstrap
{
    public IMediator Mediator { get; }
    public ServiceProvider Provider { get; }

    public MulierBootstrap()
    {
        IServiceCollection services = new ServiceCollection();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .Build();

        services.AddSingleton(configuration);
        services.AddLogging();

        services.AddApplication();
        services.AddInfrastructure(configuration);

        this.Provider = services.BuildServiceProvider();
        this.Mediator = this.Provider.GetRequiredService<IMediator>();
    }
}
