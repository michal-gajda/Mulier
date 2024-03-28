namespace Mulier.Domain.Exceptions;

public sealed class InvalidNameException : DomainException
{
    public InvalidNameException(string name) : base($"Name '{name}' is not valid")
    {
    }

    public override string Code => DomainErrorCode.INVALID_NAME;
}
