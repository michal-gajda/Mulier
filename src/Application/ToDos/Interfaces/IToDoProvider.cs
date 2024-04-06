namespace Mulier.Application.ToDos.Interfaces;

internal interface IToDoProvider
{
    Task<bool> IsUnique(string title, CancellationToken cancellationToken = default);
}
