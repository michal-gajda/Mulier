namespace Mulier.Infrastructure.LiteDb.Services;

using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;
using Mulier.Domain.Types;

internal sealed class ToDoRepository : IToDoRepository
{
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
