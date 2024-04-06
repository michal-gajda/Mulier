namespace Mulier.Application.Common.Behaviors;

using FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        => this.validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (this.validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(this.validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(result => result.Errors.Any())
                .SelectMany(result => result.Errors)
                .ToList();

            if (failures.Any())
            {
                var failure = failures[0];

                throw new ValidationException(failure.ErrorMessage);
            }
        }

        return await next();
    }
}
