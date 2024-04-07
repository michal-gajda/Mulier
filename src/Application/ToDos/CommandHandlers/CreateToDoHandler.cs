namespace Mulier.Application.ToDos.CommandHandlers;

using Mulier.Application;
using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;

internal sealed class CreateToDoHandler : IRequestHandler<CreateToDo>
{
    private readonly ILogger<CreateToDoHandler> logger;
    private readonly IPublisher mediator;
    private readonly IToDoRepository repository;

    public CreateToDoHandler(ILogger<CreateToDoHandler> logger, IPublisher mediator, IToDoRepository repository)
        => (this.logger, this.mediator, this.repository) = (logger, mediator, repository);

    public async Task Handle(CreateToDo request, CancellationToken cancellationToken)
    {
        var id = new ToDoId(request.Id);
        var entity = new ToDoEntity(id, request.Title);
        await this.repository.CreateAsync(entity, cancellationToken);
    }
}
