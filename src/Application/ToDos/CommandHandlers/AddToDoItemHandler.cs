namespace Mulier.Application.ToDos.CommandHandlers;

using Mulier.Application.Common.Interfaces;
using Mulier.Application.ToDos.Commands;
using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;

internal sealed class AddToDoItemHandler : IRequestHandler<AddToDoItem>
{
    private readonly IIdProvider idProvider;
    private readonly ILogger<AddToDoItemHandler> logger;
    private readonly IPublisher mediator;
    private readonly IToDoRepository repository;

    public AddToDoItemHandler(IIdProvider idProvider, ILogger<AddToDoItemHandler> logger, IPublisher mediator, IToDoRepository repository)
        => (this.idProvider, this.logger, this.mediator, this.repository) = (idProvider, logger, mediator, repository);

    public async Task Handle(AddToDoItem request, CancellationToken cancellationToken)
    {
        var id = new ToDoId(request.Id);

        var toDo = await this.repository.ReadAsync(id, cancellationToken);

        if (toDo is null)
        {
            throw new NullReferenceException();
        }

        var toDoItemId = new ToDoItemId(this.idProvider.GetId());
        var toToItem = new ToDoItemEntity(toDoItemId, request.Title, request.Description, request.ExpirationDateTime);
        toDo.UpsertToDoItem(toToItem);

        await this.repository.UpdateAsync(toDo, cancellationToken);
    }
}
