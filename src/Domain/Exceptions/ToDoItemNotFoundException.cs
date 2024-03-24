namespace Mulier.Domain.Exceptions;

public sealed class ToDoItemNotFoundException : DomainException
{
    public override string Code => DomainErrorCode.NOT_FOUND;

    public ToDoItemNotFoundException(ToDoItemId itemId) : base($"ToDoItem '{itemId.Value}' not found")
    {
    }
}
