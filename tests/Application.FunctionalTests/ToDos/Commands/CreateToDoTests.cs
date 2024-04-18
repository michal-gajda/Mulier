//namespace Mulier.Application.FunctionalTests.ToDos.Commands;

//using Microsoft.Extensions.DependencyInjection;
//using Mulier.Application.ToDos.Commands;
//using Mulier.Domain.Interfaces;
//using Mulier.Domain.Types;
//using Mulier.Infrastructure;

//[TestClass]
//public sealed class CreateToDoTests
//{
//    private static readonly Guid ID = new("95310a20-73c8-4ba7-8b32-c886894a8d4c");
//    private static readonly string TITLE = "Title";
//    private readonly IMediator mediator;
//    private readonly ServiceProvider provider;

//    public CreateToDoTests()
//    {
//        IServiceCollection services = new ServiceCollection();

//        IConfiguration configuration = new ConfigurationBuilder()
//            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
//            .Build();

//        services.AddSingleton(configuration);
//        services.AddLogging();

//        services.AddApplication();
//        services.AddInfrastructure(configuration);

//        this.provider = services.BuildServiceProvider();
//        this.mediator = this.provider.GetRequiredService<IMediator>();
//    }

//    [TestMethod]
//    public async Task ShouldCreateToDo()
//    {
//        var command = new CreateToDo
//        {
//            Id = ID,
//            Title = TITLE,
//        };

//        await this.mediator.Send(command);

//        var repository = this.provider.GetRequiredService<IToDoRepository>();

//        var id = new ToDoId(ID);
//        var sut = await repository.ReadAsync(id);

//        sut.Should()
//            .NotBeNull();
//    }
//}


