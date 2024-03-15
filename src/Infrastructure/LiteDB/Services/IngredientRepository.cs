namespace Mulier.Infrastructure.LiteDb.Services;

using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;
using Mulier.Domain.Types;

internal sealed class IngredientRepository : IIngredientRepository
{
    private readonly string connectionString;

    public IngredientRepository(LiteDbOptions options)
    {
        var parts = new[]
        {
            new KeyValuePair<string, string>("Filename", options.FileName),
            new KeyValuePair<string, string>("Connection", nameof(LiteDB.ConnectionType.Shared)),
        };

        this.connectionString = string.Join(";", parts.Select(part => $"{part.Key}={part.Value}"));
    }

    public Task CreateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IngredientEntity?> ReadAsync(IngredientId id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task UpdateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
