using CleanArchitectureWithDomainEvents.Application.Common.Exceptions;
using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public record CreateMovieCommand(string Title) : IRequest<Guid>;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateMovieCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var exists = _dbContext
            .Movies
            .WithSpecification(new MovieByTitleSpec(request.Title))
            .Any();

        if (exists)
        {
            throw new AlreadyExistsException("Movie Title must be unique");
        }

        var movie = Movie.Create(request.Title);

        await _dbContext.Movies.AddAsync(movie, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return movie.Id.Value;
    }
}

