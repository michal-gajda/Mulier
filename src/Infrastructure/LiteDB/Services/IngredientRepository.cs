namespace Mulier.Infrastructure.LiteDB.Services;

using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;

internal sealed class IngredientRepository : IIngredientRepository
{
    public Task CreateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
