namespace Mulier.Infrastructure.LiteDb.Services;

using AutoMapper;
using global::LiteDB;
using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;
using Mulier.Infrastructure.LiteDb.Models;

internal sealed class IngredientRepository : IIngredientRepository
{
    private readonly string connectionString;
    private readonly IMapper mapper;

    public IngredientRepository(IMapper mapper, LiteDbOptions options)
    {
        this.mapper = mapper;

        var parts = new[]
        {
            new KeyValuePair<string, string>("Filename", options.FileName),
            new KeyValuePair<string, string>("Connection", nameof(ConnectionType.Shared)),
        };

        this.connectionString = string.Join(";", parts.Select(part => $"{part.Key}={part.Value}"));
    }

    public Task CreateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
    {
        using var database = new LiteDatabase(this.connectionString);
        var dbEntities = database.GetCollection<IngredientDbEntity>(nameof(IngredientDbEntity));

        var dbEntity = this.mapper.Map<IngredientDbEntity>(entity);

        dbEntities.Insert(dbEntity);

        return Task.CompletedTask;
    }

    public Task<IngredientEntity?> ReadAsync(IngredientId id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult((IngredientEntity?)default);
    }

    public Task UpdateAsync(IngredientEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
