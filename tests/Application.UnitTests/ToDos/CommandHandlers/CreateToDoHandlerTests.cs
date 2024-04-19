namespace Mulier.Application.UnitTests.ToDos.CommandHandlers;

using MediatR;
using Mulier.Application.ToDos.CommandHandlers;
using Mulier.Application.ToDos.Commands;
using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;

[RestrictToString(false), TestClass]
public sealed class CreateToDoHandlerTests
{
    [TestMethod]
    public async Task Should_Add_ToDo_to_Repository()
    {
        // Arrange
        var logger = new NullLogger<CreateToDoHandler>();
        var sut = Substitute.For<IToDoRepository>();
        var mediator = Substitute.For<IPublisher>();
        var handler = new CreateToDoHandler(logger, mediator, sut);
        var id = Guid.NewGuid();
        var title = "title";

        var command = new CreateToDo
        {
            Id = id,
            Title = title,
        };

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        await sut
            .Received(1)
            .CreateAsync(Arg.Any<ToDoEntity>(), Arg.Any<CancellationToken>());
    }
}
