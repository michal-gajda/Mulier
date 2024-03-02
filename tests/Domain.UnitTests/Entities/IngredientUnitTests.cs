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
        var name = "name";

        //Act
        var sut = new Ingredient(ingredientId, name);

        //Assets
        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(ingredientId)
            ;

        sut.Name.Should()
            .Be(name)
            ;
    }

    [TestMethod]
    public void Should_Create_Ingredient_with_Trimmed_Name()
    {
        //Arrange
        var id = Guid.NewGuid();
        var ingredientId = new IngredientId(id);
        var name = " name ";

        //Act
        var sut = new Ingredient(ingredientId, name);

        //Assets
        var trimmedName = "name";

        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(ingredientId)
            ;

        sut.Name.Should()
            .Be(trimmedName)
            ;
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public void Should_Not_Create_Ingredient_with_Empty_Name(string name)
    {
        //Arrange
        var id = Guid.NewGuid();
        var ingredientId = new IngredientId(id);

        //Act
        var sut = () => new Ingredient(ingredientId, name);

        //Assets
        sut.Should()
            .Throw<InvalidNameException>()
            ;
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public void Should_Not_Set_Empty_Name(string newName)
    {
        //Arrange
        var id = Guid.NewGuid();
        var ingredientId = new IngredientId(id);
        var originalName = "original";
        var ingredient = new Ingredient(ingredientId, originalName);

        //Act
        var sut = () => ingredient.SetName(newName);

        //Assets
        sut.Should()
            .Throw<InvalidNameException>()
            ;
    }

    [TestMethod]
    public void Should_Set_New_Name()
    {
        //Arrange
        var id = Guid.NewGuid();
        var ingredientId = new IngredientId(id);
        var originalName = "original";
        var newName = "new";
        var sut = new Ingredient(ingredientId, originalName);

        //Act
        sut.SetName(newName);

        //Assets
        sut.Should()
            .NotBeNull()
            ;

        sut.Id.Should()
            .Be(ingredientId)
            ;

        sut.Name.Should()
            .Be(newName)
            ;
    }
}
