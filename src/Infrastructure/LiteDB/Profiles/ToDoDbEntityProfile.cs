namespace Mulier.Infrastructure.LiteDb.Profiles;

using AutoMapper;
using Mulier.Domain.Entities;
using Mulier.Infrastructure.LiteDb.Models;

internal sealed class ToDoDbEntityProfile : Profile
{
    public ToDoDbEntityProfile()
        => CreateMap<ToDoEntity, ToDoDbEntity>()
            .ForMember(target => target.Id,
                opt => opt.MapFrom(source => source.Id))
            .ForMember(target => target.Title,
                opt => opt.MapFrom(source => source.Title))
            .ReverseMap();
}
