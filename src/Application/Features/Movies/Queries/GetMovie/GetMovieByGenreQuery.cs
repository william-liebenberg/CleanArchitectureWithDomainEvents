using AutoMapper.QueryableExtensions;
using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public record GetMovieByGenreQuery(string Genre) : IRequest<IReadOnlyList<MovieDto>>;

public class GetMovieByGenreQueryHandler : IRequestHandler<GetMovieByGenreQuery, IReadOnlyList<MovieDto>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _dbContext;

    public GetMovieByGenreQueryHandler(
        IMapper mapper,
        IApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<MovieDto>> Handle(
        GetMovieByGenreQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new MovieByGenreSpec(request.Genre);

        return await _dbContext.Movies
            .WithSpecification(spec)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

