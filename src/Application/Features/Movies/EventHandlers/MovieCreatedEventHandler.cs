using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using CleanArchitectureWithDomainEvents.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public class MovieCreatedEventHandler : INotificationHandler<MovieCreatedEvent>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly ILogger<MovieCreatedEventHandler> _logger;

    public MovieCreatedEventHandler(ILogger<MovieCreatedEventHandler> logger, IApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task Handle(MovieCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Movie created: {title}", notification.NewMovie.Title);

        await Task.CompletedTask;
    }
}
