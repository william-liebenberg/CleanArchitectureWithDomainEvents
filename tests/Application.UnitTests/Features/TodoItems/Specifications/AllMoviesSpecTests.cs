using Bogus;
using CleanArchitectureWithDomainEvents.Application.Features.Movies;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.UnitTests.Features.TodoItems.Specifications;

public class AllMoviesSpecTests
{
    [Fact]
    public void Should_Return_AllItems()
    {
        const int dataCount = 10;
        var entities = new Faker<Movie>()
            .CustomInstantiator(f => Movie.Create(f.Hacker.Verb()))
            .Generate(dataCount);

        var query = new AllMoviesSpec();

        var result = query.Evaluate(entities).ToList();

        result.Count.Should().Be(dataCount);
        result.Should().Contain(entities);
    }
}