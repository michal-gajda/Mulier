namespace Mulier.Domain.Interfaces;

using Mulier.Domain.Entities;

public interface IIngredientRepository
{
    Task CreateAsync(IngredientEntity entity, CancellationToken cancellationToken = default);
    Task<IngredientEntity?> ReadAsync(IngredientId id, CancellationToken cancellationToken = default);
    Task UpdateAsync(IngredientEntity entity, CancellationToken cancellationToken = default);
}
