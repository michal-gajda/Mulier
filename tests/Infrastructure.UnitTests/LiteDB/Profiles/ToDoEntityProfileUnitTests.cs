namespace Mulier.Infrastructure.UnitTests.LiteDB.Profiles;

using AutoMapper;
using Mulier.Infrastructure.LiteDb.Models;
using Mulier.Infrastructure.LiteDb.Profiles;

[TestClass]
public sealed class ToDoEntityProfileUnitTests
{
    [TestMethod]
    public void Should_Map_All_Fields()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<ToDoDbEntityProfile>());
        var mapper = config.CreateMapper();

        var id = new ToDoId(Guid.NewGuid());
        const string TITLE = "title";

        var source = new ToDoDbEntity
        {
            Id = id,
            Title = TITLE,
        };

        //Act
        var sut = mapper.Map<ToDoDbEntity>(source);

        //Assets
        var target = new ToDoDbEntity
        {
            Id = id,
            Title = TITLE,
        };

        sut.Should()
            .BeEquivalentTo(target)
            ;
    }
}
