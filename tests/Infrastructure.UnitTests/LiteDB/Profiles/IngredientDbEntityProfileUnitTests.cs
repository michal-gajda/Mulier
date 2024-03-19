namespace Mulier.Infrastructure.UnitTests.LiteDB.Profiles;

using AutoMapper;
using Mulier.Domain.Entities;
using Mulier.Infrastructure.LiteDb.Models;
using Mulier.Infrastructure.LiteDb.Profiles;

[TestClass]
public sealed class IngredientDbEntityProfileUnitTests
{
    [TestMethod]
    public void Should_Map_All_Fields()
    {
        //Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<IngredientDbEntityProfile>());
        var mapper = config.CreateMapper();

        var id = new IngredientId(Guid.NewGuid());
        const string TITLE = "title";
        var source = new IngredientEntity(id, TITLE);

        //Act
        var sut = mapper.Map<IngredientDbEntity>(source);

        //Assets
        var target = new IngredientDbEntity
        {
            Id = id,
            Title = TITLE,
        };

        sut.Should()
            .BeEquivalentTo(target)
            ;
    }
}
