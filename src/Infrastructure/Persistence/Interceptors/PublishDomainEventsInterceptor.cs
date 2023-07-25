using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CleanArchitectureWithDomainEvents.Infrastructure.Persistence.Interceptors;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IMediator _mediator;

    public PublishDomainEventsInterceptor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        _mediator.PublishDomainEvents(eventData?.Context).ConfigureAwait(false).GetAwaiter().GetResult();
        return base.SavingChanges(eventData!, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await _mediator.PublishDomainEvents(eventData?.Context);
        return await base.SavingChangesAsync(eventData!, result, cancellationToken);
    }
}
