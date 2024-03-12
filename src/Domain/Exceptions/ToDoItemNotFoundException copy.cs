namespace Mulier.Domain.Exceptions;

public sealed class ToDoNotFoundException : Exception
{
    public ToDoNotFoundException(ToDoId id) : base($"ToDo '{id.Value}' not found")
    {
    }
}
