using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureWithDomainEvents.Domain.Common.Interfaces;
using CleanArchitectureWithDomainEvents.Domain.Common.Base;

namespace CleanArchitectureWithDomainEvents.Infrastructure.Persistence.Interceptors;

public static class DomainEventExtensions
{
    public static async Task PublishDomainEvents(this IMediator mediator, DbContext? context)
    {
        if (mediator is null || context is null)
        {
            return;
        }

        IEnumerable<IDomainEvents> entities = context.ChangeTracker
            .Entries<IDomainEvents>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        List<DomainEvent> domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        // clear the domain events before publish to prevent recursion
        entities.ToList().ForEach(e => e.ClearDomainEvents());

        // publish the domain events
        foreach (DomainEvent domainEvent in domainEvents)
        {
            await mediator
                .Publish(domainEvent)
                .ConfigureAwait(false);
        }
    }
}