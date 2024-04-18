namespace Mulier.Domain.UnitTests.Entities;

using Mulier.Domain.Entities;

[RestrictToString(false), TestClass]
public sealed class ToDoItemEntityUnitTests
{
    [TestMethod]
    public void Should_Create_ToDo()
    {
        //Arrange
        var id = Guid.NewGuid();
        var toDoItemId = new ToDoItemId(id);
        var title = "name";
        var description = "description";

        //Act
        var sut = new ToDoItemEntity(toDoItemId, title, description);

        //Assets
        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(toDoItemId)
            ;

        sut.Title.Should()
            .Be(title)
            ;

        sut.Description.Should()
            .Be(description)
            ;
    }
}
