namespace Mulier.Application.ToDos.Validators;

using FluentValidation;
using Mulier.Application.ToDos.Commands;
using Mulier.Application.ToDos.Interfaces;
using Mulier.Domain.Common.Constants;

internal sealed class CreateToDoValidator : AbstractValidator<CreateToDo>
{
    private readonly IToDoProvider provider;

    public CreateToDoValidator(IToDoProvider provider)
    {
        this.provider = provider;

        base.RuleFor(command => command.Title)
            .NotEmpty()
            .MustAsync(BeUniqueTitle)
            .WithMessage("'{PropertyName}' must be unique.")
            .WithErrorCode(DomainErrorCode.INVALID_TITLE);
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken = default)
    {
        return await this.provider.IsUnique(title, cancellationToken);
    }
}