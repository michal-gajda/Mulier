namespace Mulier.Domain.Exceptions;

public sealed class InvalidTitleException : DomainException
{
    public override string Code => DomainErrorCode.INVALID_TITLE;

    public InvalidTitleException(string title) : base($"Name '{title}' is not valid")
    {
    }
}
