using AutoMapper.QueryableExtensions;
using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public record GetMovieByKeywordSearchQuery(string Keyword) : IRequest<IReadOnlyList<MovieDto>>;

public class GetMovieByKeywordSearchQueryHandler : IRequestHandler<GetMovieByKeywordSearchQuery, IReadOnlyList<MovieDto>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _dbContext;

    public GetMovieByKeywordSearchQueryHandler(
        IMapper mapper,
        IApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<MovieDto>> Handle(
        GetMovieByKeywordSearchQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new MovieSearchSpec(request.Keyword);

        return await _dbContext.Movies
            .WithSpecification(spec)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}