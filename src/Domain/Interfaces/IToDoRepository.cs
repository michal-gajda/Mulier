namespace Mulier.Domain.Interfaces;

using Mulier.Domain.Entities;

public interface IToDoRepository
{
    Task CreateAsync(ToDoEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(ToDoId id, CancellationToken cancellationToken = default);
    Task<ToDoEntity?> ReadAsync(ToDoId id, CancellationToken cancellationToken = default);
    Task UpdateAsync(ToDoEntity entity, CancellationToken cancellationToken = default);
}
