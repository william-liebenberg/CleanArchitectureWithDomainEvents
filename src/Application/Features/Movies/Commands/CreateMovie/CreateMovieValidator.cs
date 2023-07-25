namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(m => m.Title)
            .NotNull()
            .NotEmpty();
    }
}