namespace Mulier.Infrastructure.LiteDB.Services;

using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;
using Mulier.Domain.Types;

internal sealed class IngredientRepository : IIngredientRepository
{
    public Task CreateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IngredientEntity?> ReadAsync(IngredientId id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task UpdateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
