using CleanArchitectureWithDomainEvents.Domain.Common.Base;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Domain.Events;

public record TodoItemCompletedEvent(TodoItem Item) : DomainEvent;
