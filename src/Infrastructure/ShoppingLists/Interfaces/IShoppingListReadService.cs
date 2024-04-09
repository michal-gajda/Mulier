namespace Mulier.Infrastructure.ShoppingLists.Interfaces;

using Mulier.Infrastructure.ShoppingLists.Models;

internal interface IShoppingListReadService
{
    Task<IEnumerable<ShoppingListItemDbEntity>> GetShoppingListItems(ShoppingListId id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ShoppingListDbEntity>> GetShoppingLists(CancellationToken cancellationToken = default);
}
