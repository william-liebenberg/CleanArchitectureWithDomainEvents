using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using CleanArchitectureWithDomainEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public record UpdateMovieCommand(Guid Id, string Genre, double Rating, double LengthMinutes) : IRequest<Guid>;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateMovieCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var searchId = new MovieId(request.Id);
        Movie? movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == searchId, cancellationToken: cancellationToken);

        if (movie is null)
        {
            return Guid.Empty;
        }

        movie.Update(request.Genre, request.Rating, request.LengthMinutes);

        _dbContext.Movies.Update(movie);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return movie.Id.Value;
    }
}
