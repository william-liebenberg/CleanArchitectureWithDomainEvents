using CleanArchitectureWithDomainEvents.Application.Features.Movies;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.UnitTests.Features.TodoItems.Specifications;

public class MovieByTitleSpecTests
{
    private readonly List<Movie> _entities;

    public MovieByTitleSpecTests()
    {
        _entities = new List<Movie>()
        {
            Movie.Create("Avengers"),
            Movie.Create("Iron Man"),
            Movie.Create("Captain Marvel"),
            Movie.Create("The Hulk")
        };
    }

    [Theory]
    [InlineData("Avengers")]
    [InlineData("The Hulk")]
    public void Should_Return_ByTitle(string textToSearch)
    {
        var query = new MovieByTitleSpec(textToSearch);
        var result = query.Evaluate(_entities).ToList();

        result.Count.Should().Be(1);
        result.First().Title.Should().Be(textToSearch);
    }
}