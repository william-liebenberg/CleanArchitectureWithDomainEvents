using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Domain.UnitTests.Entities;

public class MovieTests
{
    [Fact]
    public void Create_Should_Succeed_When_Title_Valid()
    {
        // Arrange
        var title = "title";

        // Act
        var todoItem = Movie.Create(title);

        // Assert
        todoItem.Should().NotBeNull();
        todoItem.Title.Should().Be(title);
    }

    [Fact]
    public void Create_Should_Throw_When_Title_Null()
    {
        // Arrange
        string? title = null;

        // Act
        Action act = () => Movie.Create(title!);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'title')");
    }

    [Fact]
    public void Update_Should_Throw_When_Genre_Null()
    {
        // Arrange
        var movie = Movie.Create("title");
        string? genre = null!;

        // Act
        Action act = () => movie.Update(genre, 1, 120);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'genre')");
    }

    [Fact]
    public void Create_Should_Raise_Domain_Event()
    {
        // Act
        var todoItem = Movie.Create("title");

        // Assert
        todoItem.DomainEvents.Should().NotBeNull();
        todoItem.DomainEvents.Should().HaveCount(1);
        todoItem.DomainEvents.Should().ContainSingle(x => x is MovieCreatedEvent);
    }

    [Fact]
    public void Update_Should_Raise_Domain_Event()
    {
        // Arrange
        var todoItem = Movie.Create("title");

        // Act
        todoItem.Update("generic", 1, 120);

        // Assert
        todoItem.DomainEvents.Should().NotBeNull();
        todoItem.DomainEvents.Should().HaveCount(2);
        todoItem.DomainEvents.Should().ContainSingle(x => x is MovieUpdatedEvent);
    }
}