namespace Mulier.Application.ToDos.Services;

using Mulier.Application.ToDos.Interfaces;

internal sealed class ToDoProvider : IToDoProvider
{
    public Task<bool> IsUnique(string title, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }
}
