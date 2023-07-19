using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Features.TodoItems.Queries.GetAllTodoItems;

public class GetAllTodoItemsMapping : Profile
{
    public GetAllTodoItemsMapping()
    {
        CreateMap<TodoItem, TodoItemDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id.Value));
    }
}