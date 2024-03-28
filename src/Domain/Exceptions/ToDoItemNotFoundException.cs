namespace Mulier.Domain.Exceptions;

public sealed class ToDoItemNotFoundException : DomainException
{
    public ToDoItemNotFoundException(ToDoItemId itemId) : base($"ToDoItem '{itemId.Value}' not found")
    {
    }

    public override string Code => DomainErrorCode.NOT_FOUND;
}
