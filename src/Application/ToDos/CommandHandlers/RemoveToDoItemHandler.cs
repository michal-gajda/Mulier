namespace Mulier.Application.ToDos.CommandHandlers;

using Mulier.Application.ToDos.Commands;
using Mulier.Domain.Exceptions;
using Mulier.Domain.Interfaces;

internal sealed class RemoveToDoItemHandler : IRequestHandler<RemoveToDoItem>
{
    private readonly ILogger<RemoveToDoItemHandler> logger;
    private readonly IPublisher mediator;
    private readonly IToDoRepository repository;

    public RemoveToDoItemHandler(ILogger<RemoveToDoItemHandler> logger, IPublisher mediator, IToDoRepository repository)
        => (this.logger, this.mediator, this.repository) = (logger, mediator, repository);

    public async Task Handle(RemoveToDoItem request, CancellationToken cancellationToken)
    {
        var id = new ToDoId(request.Id);

        var toDo = await this.repository.ReadAsync(id, cancellationToken);

        if (toDo is null)
        {
            throw new ToDoNotFoundException(id);
        }

        var toDoItemId = new ToDoItemId(request.ItemId);
        toDo.RemoveToDoItem(toDoItemId);

        await this.repository.UpdateAsync(toDo, cancellationToken);
    }
}
