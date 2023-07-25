using Bogus;
using CleanArchitectureWithDomainEvents.Application.Features.Movies;
using CleanArchitectureWithDomainEvents.Application.IntegrationTests.TestHelpers;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.IntegrationTests.Features.TodoItems.Queries.GetAllTodoItems;

public class GetAllMoviesQueryTests : IntegrationTestBase
{
    public GetAllMoviesQueryTests(TestingDatabaseFixture fixture) : base(fixture) { }

    [Fact]
    public async Task Should_Return_All_Movies()
    {
        const int entityCount = 10;
        var entities = new Faker<Movie>()
            .CustomInstantiator(f => Movie.Create(f.UniqueIndex.ToString()))
            .Generate(entityCount);

        await Context.Movies.AddRangeAsync(entities);
        await Context.SaveChangesAsync();

        var result = await Mediator.Send(new GetAllMoviesQuery());

        result.Count.Should().Be(entityCount);
    }
}