namespace Mulier.Infrastructure.MassTransit.EventHandlers;

using Mulier.Application.ShoppingLists.Events;

internal sealed class ShoppingListCreatedHandler : INotificationHandler<ShoppingListCreated>
{
    public Task Handle(ShoppingListCreated notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
