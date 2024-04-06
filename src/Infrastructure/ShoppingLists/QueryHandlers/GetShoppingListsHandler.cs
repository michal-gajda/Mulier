namespace Mulier.Infrastructure.ShoppingLists.QueryHandlers;

using AutoMapper;
using Mulier.Application.ShoppingLists.Queries;
using Mulier.Application.ShoppingLists.ViewModels;
using Mulier.Infrastructure.ShoppingLists.Interfaces;

internal sealed class GetShoppingListsHandler : IRequestHandler<GetShoppingLists, IEnumerable<ShoppingList>>
{
    private readonly IMapper mapper;
    private readonly IShoppingListReadService readService;

    public GetShoppingListsHandler(IMapper mapper, IShoppingListReadService readService)
        => (this.mapper, this.readService) = (mapper, readService);

    public async Task<IEnumerable<ShoppingList>> Handle(GetShoppingLists request, CancellationToken cancellationToken)
    {
        var source = await this.readService.GetShoppingLists(cancellationToken);
        var target = this.mapper.Map<IEnumerable<ShoppingList>>(source);

        return target;
    }
}
