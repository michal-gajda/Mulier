namespace Mulier.Application.FunctionalTests.ToDos.Commands;

using Mulier.Application.ToDos.Commands;

[TestClass]
public sealed class CreateToDoTests
{
    private static readonly Guid ID = new("95310a20-73c8-4ba7-8b32-c886894a8d4c");
    private static readonly string TITLE = "Title";

    [TestMethod]
    public void ShouldCreateToDo()
    {
        var command = new CreateToDo
        {
            Id = ID,
            Title = TITLE,
        };
    }
}
