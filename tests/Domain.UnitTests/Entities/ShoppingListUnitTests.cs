namespace Mulier.Domain.UnitTests.Entities;

using Mulier.Domain.Entities;
using Mulier.Domain.Exceptions;

[TestClass]
public sealed class ShoppingListUnitTests
{
    [TestMethod]
    public void Should_Create_ShoppingList()
    {
        //Arrange
        var id = Guid.NewGuid();
        var shoppingListId = new ShoppingListId(id);
        var title = "name";

        //Act
        var sut = new ShoppingListEntity(shoppingListId, title);

        //Assets
        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(shoppingListId)
            ;

        sut.Title.Should()
            .Be(title)
            ;
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public void Should_Not_Create_ShoppingList_with_Empty_Title(string title)
    {
        //Arrange
        var id = Guid.NewGuid();
        var shoppingListId = new ShoppingListId(id);

        //Act
        var sut = () => new ShoppingListEntity(shoppingListId, title);

        //Assets
        sut.Should()
            .Throw<InvalidTitleException>()
            ;
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public void Should_Not_Set_Empty_Title(string newTitle)
    {
        //Arrange
        var id = Guid.NewGuid();
        var shoppingListId = new ShoppingListId(id);
        var oldTitle = "original";
        var shoppingList = new ShoppingListEntity(shoppingListId, oldTitle);

        //Act
        var sut = () => shoppingList.SetTitle(newTitle);

        //Assets
        sut.Should()
            .Throw<InvalidTitleException>()
            ;
    }
}
