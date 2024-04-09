namespace Mulier.Domain.Exceptions;

public sealed class InvalidNameException : DomainException
{
    public override string Code => DomainErrorCode.INVALID_NAME;

    public InvalidNameException(string name) : base($"Name '{name}' is not valid")
    {
    }
}
