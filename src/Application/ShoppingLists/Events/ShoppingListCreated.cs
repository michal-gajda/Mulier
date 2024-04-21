namespace Mulier.Application.ShoppingLists.Events;

public sealed record ShoppingListCreated : INotification
{
    public required ShoppingListId Id { get; init; }
}
