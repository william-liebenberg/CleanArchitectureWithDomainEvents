using CleanArchitectureWithDomainEvents.Application.Common.Exceptions;
using CleanArchitectureWithDomainEvents.Application.Features.TodoItems.Commands.CreateTodoItem;
using CleanArchitectureWithDomainEvents.Application.IntegrationTests.TestHelpers;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.IntegrationTests.Features.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommandTests : IntegrationTestBase
{
    public CreateTodoItemCommandTests(TestingDatabaseFixture fixture) : base(fixture) { }

    [Fact]
    public async Task ShouldRequireUniqueTitle()
    {
        await Mediator.Send(new CreateTodoItemCommand("Shopping"));

        var command = new CreateTodoItemCommand("Shopping");

        await FluentActions.Invoking(() =>
            Mediator.Send(command)).Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ShouldCreateTodoItem()
    {
        var command = new CreateTodoItemCommand("Tasks");

        var id = await Mediator.Send(command);

        var item = (await Context.TodoItems.FindAsync(new TodoItemId(id)))!;

        item.Should().NotBeNull();
        item.Title.Should().Be(command.Title);
        item.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(10));
    }
}