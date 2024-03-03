namespace Mulier.Domain.Interfaces;

using Mulier.Domain.Entities;

public interface IIngredientRepository
{
    Task CreateAsync(IngredientEntity entity, CancellationToken cancellationToken = default);
}
