namespace Mulier.Domain.Exceptions;

public sealed class ToDoItemNotFoundException : Exception
{
    public ToDoItemNotFoundException(ToDoItemId itemId) : base($"ToDoItem '{itemId.Value}' not found")
    {
    }
}
