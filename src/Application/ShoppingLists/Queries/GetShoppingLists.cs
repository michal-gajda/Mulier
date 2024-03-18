namespace Mulier.Application.ShoppingLists.Queries;

using Mulier.Application.ShoppingLists.ViewModels;

public sealed record class GetShoppingLists : IRequest<IEnumerable<ShoppingList>>
{
}
