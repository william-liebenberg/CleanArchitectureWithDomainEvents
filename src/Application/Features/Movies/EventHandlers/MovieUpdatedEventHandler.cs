using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using CleanArchitectureWithDomainEvents.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public class MovieUpdatedEventHandler : INotificationHandler<MovieUpdatedEvent>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly ILogger<MovieUpdatedEventHandler> _logger;

    public MovieUpdatedEventHandler(ILogger<MovieUpdatedEventHandler> logger, IApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task Handle(MovieUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Movie updated from {oldTitle} to {newTitle}", notification.OldMovie.Title, notification.NewMovie.Title);

        await Task.CompletedTask;
    }
}
