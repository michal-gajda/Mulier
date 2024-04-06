namespace Mulier.Domain.UnitTests.Entities;

using Mulier.Domain.Entities;

[TestClass]
public sealed class ToDoEntityUnitTests
{
    [TestMethod]
    public void Should_Create_ToDo()
    {
        //Arrange
        var id = Guid.NewGuid();
        var toDoId = new ToDoId(id);
        var title = "name";

        //Act
        var sut = new ToDoEntity(toDoId, title);

        //Assets
        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(toDoId)
            ;

        sut.Title.Should()
            .Be(title)
            ;
    }
}
