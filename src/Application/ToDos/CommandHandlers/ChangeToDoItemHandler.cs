namespace Mulier.Application.ToDos.CommandHandlers;

using Mulier.Application.ToDos.Commands;
using Mulier.Domain.Entities;
using Mulier.Domain.Exceptions;
using Mulier.Domain.Interfaces;

internal sealed class ChangeToDoItemHandler : IRequestHandler<ChangeToDoItem>
{
    private readonly ILogger<ChangeToDoItemHandler> logger;
    private readonly IPublisher mediator;
    private readonly IToDoRepository repository;

    public ChangeToDoItemHandler(ILogger<ChangeToDoItemHandler> logger, IPublisher mediator, IToDoRepository repository)
        => (this.logger, this.mediator, this.repository) = (logger, mediator, repository);

    public async Task Handle(ChangeToDoItem request, CancellationToken cancellationToken)
    {
        var id = new ToDoId(request.Id);

        var toDo = await this.repository.ReadAsync(id, cancellationToken);

        if (toDo is null)
        {
            throw new ToDoNotFoundException(id);
        }

        var toDoItemId = new ToDoItemId(request.ItemId);
        var toToItem = new ToDoItemEntity(toDoItemId, request.Title, request.Description, request.ExpirationDateTime);
        toDo.UpsertToDoItem(toToItem);

        await this.repository.UpdateAsync(toDo, cancellationToken);
    }
}
