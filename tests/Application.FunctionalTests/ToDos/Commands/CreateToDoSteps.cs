namespace Mulier.Application.FunctionalTests.ToDos.Commands;

using Mulier.Application.ToDos.Commands;
using Mulier.Domain.Interfaces;
using Mulier.Domain.Types;
using TechTalk.SpecFlow;

[Binding]
public sealed class CreateToDoSteps
{
    private static readonly Guid ID = Guid.NewGuid();
    private static readonly string TITLE = "Title";
    private readonly MulierBootstrap mulierBootstrap;
    private ToDoId createdToDoId;

    public CreateToDoSteps(MulierBootstrap mulierBootstrap)
    {
        this.mulierBootstrap = mulierBootstrap;
    }

    [Given(@"I have a valid ToDo creation command")]
    public void GivenIHaveAValidToDoCreationCommand()
    {
        // This step can be used to prepare test data or context if needed
    }

    [Then(@"the ToDo item should be created in the repository")]
    public async Task ThenTheToDoItemShouldBeCreatedInTheRepository()
    {
        var repository = this.mulierBootstrap.Provider.GetRequiredService<IToDoRepository>();
        var sut = await repository.ReadAsync(this.createdToDoId);

        sut.Should()
            .NotBeNull()
            ;
    }

    [When(@"I send the command to create a ToDo item")]
    public async Task WhenISendTheCommandToCreateAToDoItem()
    {
        var command = new CreateToDo
        {
            Id = ID,
            Title = TITLE,
        };

        await this.mulierBootstrap.Mediator.Send(command);

        this.createdToDoId = new ToDoId(ID);
    }
}
