﻿using CleanArchitectureWithDomainEvents.Domain.Common.Base;

namespace CleanArchitectureWithDomainEvents.Domain.Common.Interfaces;

public interface IDomainEvents
{
    IReadOnlyList<DomainEvent> DomainEvents { get; }

    void AddDomainEvent(DomainEvent domainEvent);

    void RemoveDomainEvent(DomainEvent domainEvent);

    void ClearDomainEvents();
}