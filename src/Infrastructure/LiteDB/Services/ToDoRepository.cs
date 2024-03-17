namespace Mulier.Infrastructure.LiteDb.Services;

using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;
using Mulier.Domain.Types;

internal sealed class ToDoRepository : IToDoRepository
{
    private readonly string connectionString;

    public ToDoRepository(LiteDbOptions options)
    {
        var parts = new[]
        {
            new KeyValuePair<string, string>("Filename", options.FileName),
            new KeyValuePair<string, string>("Connection", nameof(LiteDB.ConnectionType.Shared)),
        };

        this.connectionString = string.Join(";", parts.Select(part => $"{part.Key}={part.Value}"));
    }

    public Task CreateAsync(ToDoEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(ToDoId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoEntity?> ReadAsync(ToDoId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ToDoEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
