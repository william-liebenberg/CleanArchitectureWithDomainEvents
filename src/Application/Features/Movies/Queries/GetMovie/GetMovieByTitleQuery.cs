using AutoMapper.QueryableExtensions;
using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public record GetMovieByTitleQuery(string Title) : IRequest<IReadOnlyList<MovieDto>>;

public class GetMovieByTitleQueryHandler : IRequestHandler<GetMovieByTitleQuery, IReadOnlyList<MovieDto>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _dbContext;

    public GetMovieByTitleQueryHandler(
        IMapper mapper,
        IApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<MovieDto>> Handle(
        GetMovieByTitleQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new MovieByTitleSpec(request.Title);

        return await _dbContext.Movies
            .WithSpecification(spec)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

