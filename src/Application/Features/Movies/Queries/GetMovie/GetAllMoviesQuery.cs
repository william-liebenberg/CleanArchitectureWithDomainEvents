using AutoMapper.QueryableExtensions;
using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public record GetAllMoviesQuery() : IRequest<IReadOnlyList<MovieDto>>;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IReadOnlyList<MovieDto>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _dbContext;

    public GetAllMoviesQueryHandler(
        IMapper mapper,
        IApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<MovieDto>> Handle(
        GetAllMoviesQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new AllMoviesSpec();

        return await _dbContext.Movies
            .WithSpecification(spec)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
