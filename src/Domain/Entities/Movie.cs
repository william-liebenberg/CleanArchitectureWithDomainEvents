using CleanArchitectureWithDomainEvents.Domain.Common.Base;

namespace CleanArchitectureWithDomainEvents.Domain.Entities;

public record MovieId(Guid Value);

public record MovieCreatedEvent(Movie NewMovie) : DomainEvent;
public record MovieUpdatedEvent(Movie OldMovie, Movie NewMovie) : DomainEvent;

public class Movie : BaseEntity<MovieId>
{
    public string Title { get; private set; } = string.Empty;
    public string Genre { get; private set; } = string.Empty;
    public double Rating { get; private set; }
    public TimeSpan Length { get; private set; } = TimeSpan.FromMinutes(0);

    public void Update(string genre, double rating, double lengthMinutes)
    {
        ArgumentException.ThrowIfNullOrEmpty(genre, nameof(genre));

        if (rating < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rating));
        }

        if (lengthMinutes < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(lengthMinutes));
        }

        var original = new Movie(this);

        Genre = genre;
        Length = TimeSpan.FromMinutes(lengthMinutes);
        Rating = rating;

        AddDomainEvent(new MovieUpdatedEvent(original, this));
    }

    public static Movie Create(string title)
    {
        ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

        var m = new Movie
        {
            Title = title,
        };

        m.AddDomainEvent(new MovieCreatedEvent(m));

        return m;
    }

    public static Movie Create(string title, string genre, double rating, TimeSpan length)
    {
        ArgumentException.ThrowIfNullOrEmpty(genre, nameof(genre));

        if (rating < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rating));
        }

        if (length.TotalMinutes < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        var m = Create(title);

        m.Genre = genre;
        m.Length = length;
        m.Rating = rating;

        return m;
    }

    private Movie()
    {
    }

    private Movie(Movie other)
    {
        Title = other.Title;
        Genre = other.Genre;
        Rating = other.Rating;
        Length = other.Length;
    }
}