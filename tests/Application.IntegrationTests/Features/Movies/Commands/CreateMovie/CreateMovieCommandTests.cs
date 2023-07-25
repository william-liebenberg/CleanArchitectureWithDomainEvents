using CleanArchitectureWithDomainEvents.Application.Common.Exceptions;
using CleanArchitectureWithDomainEvents.Application.Features.Movies;
using CleanArchitectureWithDomainEvents.Application.IntegrationTests.TestHelpers;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.IntegrationTests.Features.TodoItems.Commands.CreateTodoItem;

public class CreateMovieCommandTests : IntegrationTestBase
{
    public CreateMovieCommandTests(TestingDatabaseFixture fixture) : base(fixture) { }

    [Fact]
    public async Task ShouldRequireUniqueTitle()
    {
        await Mediator.Send(new CreateMovieCommand("Superman"));

        var command = new CreateMovieCommand("Superman");

        await FluentActions.Invoking(() =>
            Mediator.Send(command)).Should().ThrowAsync<AlreadyExistsException>();
    }

    [Fact]
    public async Task ShouldCreateMovie()
    {
        var command = new CreateMovieCommand("Batman");

        var id = await Mediator.Send(command);

        var item = (await Context.Movies.FindAsync(new MovieId(id)))!;

        item.Should().NotBeNull();
        item.Title.Should().Be(command.Title);
        item.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(10));
    }
}