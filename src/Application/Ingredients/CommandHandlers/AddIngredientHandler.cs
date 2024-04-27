namespace Mulier.Application.Ingredients.CommandHandlers;

using Mulier.Application.Ingredients.Commands;
using Mulier.Application.Ingredients.Events;
using Mulier.Domain.Entities;
using Mulier.Domain.Interfaces;

internal sealed class AddIngredientHandler : IRequestHandler<AddIngredient>
{
    private readonly ILogger<AddIngredientHandler> logger;
    private readonly IPublisher mediator;
    private readonly IIngredientRepository repository;

    public AddIngredientHandler(ILogger<AddIngredientHandler> logger, IPublisher mediator, IIngredientRepository repository)
        => (this.logger, this.mediator, this.repository) = (logger, mediator, repository);

    public async Task Handle(AddIngredient request, CancellationToken cancellationToken)
    {
        var ingredientId = new IngredientId(request.Id);
        var entity = new IngredientEntity(ingredientId, request.Name);
        this.logger.LogInformation("Creating {IngredientId} ingredient", ingredientId.Value);
        await this.repository.CreateAsync(entity, cancellationToken);
        this.logger.LogInformation("Created {IngredientId} ingredient", ingredientId.Value);

        var @event = new IngredientAdded
        {
            Id = ingredientId,
        };

        await this.mediator.Publish(@event, cancellationToken);
    }
}
