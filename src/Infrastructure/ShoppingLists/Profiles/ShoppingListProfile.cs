namespace Mulier.Infrastructure.ShoppingLists.Profiles;

using Source = Mulier.Infrastructure.ShoppingLists.Models.ShoppingListDbEntity;
using Target = Mulier.Application.ShoppingLists.ViewModels.ShoppingList;

internal sealed class ShoppingListProfile : AutoMapper.Profile
{
    public ShoppingListProfile()
    {
        base.CreateMap<Source, Target>()
            .ReverseMap();
    }
}
