namespace Mulier.Application.UnitTests.Ingredients.CommandHandlers;

using Microsoft.Extensions.Logging.Abstractions;
using Mulier.Application.Ingredients.CommandHandlers;
using Mulier.Application.Ingredients.Commands;
using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;
using NSubstitute;

[TestClass]
public sealed class AddIngredientHandlerUnitTests
{
    [TestMethod]
    public async Task Should_Add_Ingredient_to_Repository()
    {
        // Arrange
        var logger = new NullLogger<AddIngredientHandler>();
        var sut = Substitute.For<IIngredientRepository>();
        var handler = new AddIngredientHandler(logger, sut);

        var id = Guid.NewGuid();
        var name = "name";

        var command = new AddIngredient
        {
            Id = id,
            Name = name,
        };

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        await sut
            .Received(1)
            .CreateAsync(Arg.Any<IngredientEntity>(), Arg.Any<CancellationToken>());
    }
}
