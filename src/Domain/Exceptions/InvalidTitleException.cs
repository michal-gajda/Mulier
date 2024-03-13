namespace Mulier.Domain.Exceptions;

public sealed class InvalidTitleException : Exception
{
    public InvalidTitleException(string title) : base($"Name '{title}' is not valid")
    {
    }
}
