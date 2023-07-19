using Bogus;
using CleanArchitectureWithDomainEvents.Application.Features.TodoItems.Specifications;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.UnitTests.Features.TodoItems.Specifications;

public class AllTodoItemSpecTests
{
    [Fact]
    public void Should_Return_AllItems()
    {
        const int dataCount = 10;
        var entities = new Faker<TodoItem>()
            .CustomInstantiator(f => TodoItem.Create(f.Commerce.ProductName()))
            .Generate(dataCount);

        var query = new AllTodoItemSpec();

        var result = query.Evaluate(entities).ToList();

        result.Count.Should().Be(dataCount);
        result.Should().Contain(entities);
    }
}