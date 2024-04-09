namespace Mulier.Infrastructure.LiteDb.Profiles;

using AutoMapper;
using Mulier.Domain.Entities;
using Mulier.Infrastructure.LiteDb.Models;

internal sealed class IngredientDbEntityProfile : Profile
{
    public IngredientDbEntityProfile()
        => CreateMap<IngredientEntity, IngredientDbEntity>()
            .ForMember(target => target.Id,
                opt => opt.MapFrom(source => source.Id))
            .ForMember(target => target.Title,
                opt => opt.MapFrom(source => source.Title));
}
