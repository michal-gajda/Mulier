namespace Mulier.Domain.UnitTests.Entities;

using Mulier.Domain.Entities;
using Mulier.Domain.Exceptions;

[TestClass]
public sealed class IngredientUnitTests
{
    [TestMethod]
    public void Should_Create_Ingredient()
    {
        //Arrange
        var id = Guid.NewGuid();
        var ingredientId = new IngredientId(id);
        var title = "name";

        //Act
        var sut = new IngredientEntity(ingredientId, title);

        //Assets
        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(ingredientId)
            ;

        sut.Title.Should()
            .Be(title)
            ;
    }

    [TestMethod]
    public void Should_Create_Ingredient_with_Trimmed_Name()
    {
        //Arrange
        var id = Guid.NewGuid();
        var ingredientId = new IngredientId(id);
        var title = " name ";

        //Act
        var sut = new IngredientEntity(ingredientId, title);

        //Assets
        var trimmedTitle = "name";

        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(ingredientId)
            ;

        sut.Title.Should()
            .Be(trimmedTitle)
            ;
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public void Should_Not_Create_Ingredient_with_Empty_Title(string title)
    {
        //Arrange
        var id = Guid.NewGuid();
        var ingredientId = new IngredientId(id);

        //Act
        var sut = () => new IngredientEntity(ingredientId, title);

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
        var ingredientId = new IngredientId(id);
        var oldTitle = "original";
        var ingredient = new IngredientEntity(ingredientId, oldTitle);

        //Act
        var sut = () => ingredient.SetTitle(newTitle);

        //Assets
        sut.Should()
            .Throw<InvalidTitleException>()
            ;
    }

    [TestMethod]
    public void Should_Set_New_Title()
    {
        //Arrange
        var id = Guid.NewGuid();
        var ingredientId = new IngredientId(id);
        var oldTitle = "original";
        var newTitle = "new";
        var sut = new IngredientEntity(ingredientId, oldTitle);

        //Act
        sut.SetTitle(newTitle);

        //Assets
        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(ingredientId)
            ;

        sut.Title.Should()
            .Be(newTitle)
            ;
    }
}
