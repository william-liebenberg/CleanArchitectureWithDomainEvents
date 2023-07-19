using CleanArchitectureWithDomainEvents.Domain.Common.Base;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Domain.Events;

public record TodoItemCreatedEvent(TodoItem Item) : DomainEvent;
