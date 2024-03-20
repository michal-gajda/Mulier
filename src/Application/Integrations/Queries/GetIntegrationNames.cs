namespace Mulier.Application.ToDos.Commands;

public sealed record class GetIntegrationNames : IRequest<IEnumerable<string>>
{
}
