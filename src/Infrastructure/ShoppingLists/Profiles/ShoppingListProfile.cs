namespace Mulier.Infrastructure.ShoppingLists.Profiles;

using AutoMapper;
using Source = Mulier.Infrastructure.ShoppingLists.Models.ShoppingListDbEntity;
using Target = Mulier.Application.ShoppingLists.ViewModels.ShoppingList;

internal sealed class ShoppingListProfile : Profile
{
    public ShoppingListProfile()
        => CreateMap<Source, Target>()
            .ReverseMap();
}
