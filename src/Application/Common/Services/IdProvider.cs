namespace Mulier.Application.Common.Services;

using Mulier.Application.Common.Interfaces;

public sealed class IdProvider : IIdProvider
{
    public Guid GetId() => Guid.NewGuid();
}
