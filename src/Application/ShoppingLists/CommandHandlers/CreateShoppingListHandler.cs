namespace Mulier.Application.ShoppingLists.CommandHandlers;

using Mulier.Application.ShoppingLists.Commands;
using Mulier.Application.ShoppingLists.Events;

internal sealed class CreateShoppingListHandler : IRequestHandler<CreateShoppingList>
{
    private readonly ILogger<CreateShoppingListHandler> logger;
    private readonly IPublisher mediator;

    public CreateShoppingListHandler(ILogger<CreateShoppingListHandler> logger, IPublisher mediator)
        => (this.logger, this.mediator) = (logger, mediator);

    public async Task Handle(CreateShoppingList request, CancellationToken cancellationToken)
    {
        var shoppingListId = new ShoppingListId(request.Id);

        var @event = new ShoppingListCreated
        {
            Id = shoppingListId
        };

        await this.mediator.Publish(@event, cancellationToken);
    }
}
