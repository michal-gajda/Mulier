namespace Mulier.Infrastructure.EntityFrameworkCore.Services;

using AutoMapper;
using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;
using Mulier.Domain.Types;
using Mulier.Infrastructure.EntityFrameworkCore.Models;

internal sealed class IngredientRepository : IIngredientRepository
{
    private readonly MulierDbContext context;
    private readonly IMapper mapper;

    public IngredientRepository(MulierDbContext context, IMapper mapper)
        => (this.context, this.mapper) = (context, mapper);

    public async Task CreateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
    {
        var ingredient = this.mapper.Map<IngredientDbEntity>(entity);
        await this.context.Ingredients.AddAsync(ingredient, cancellationToken);
        await this.context.SaveChangesAsync(cancellationToken);
    }

    public Task<IngredientEntity?> ReadAsync(IngredientId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
