namespace Mulier.Application.Ingredients.CommandHandlers;

using Mulier.Application.Ingredients.Commands;
using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;

internal sealed class AddIngredientHandler : IRequestHandler<AddIngredient>
{
    private readonly ILogger<AddIngredientHandler> logger;
    private readonly IIngredientRepository repository;

    public AddIngredientHandler(ILogger<AddIngredientHandler> logger, IIngredientRepository repository)
        => (this.logger, this.repository) = (logger, repository);

    public async Task Handle(AddIngredient request, CancellationToken cancellationToken)
    {
        var ingredientId = new IngredientId(request.Id);
        var entity = new IngredientEntity(ingredientId, request.Name);
        this.logger.LogInformation("Creating {IngredientId} ingredient", ingredientId.Value);
        await this.repository.CreateAsync(entity, cancellationToken);
        this.logger.LogInformation("Created {IngredientId} ingredient", ingredientId.Value);
    }
}
