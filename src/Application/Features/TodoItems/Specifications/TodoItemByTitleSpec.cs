using Ardalis.Specification;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Features.TodoItems.Specifications;

public sealed class TodoItemByTitleSpec : Specification<TodoItem>
{
    public TodoItemByTitleSpec(string title)
    {
        Query.Where(i => i.Title == title);
    }
}