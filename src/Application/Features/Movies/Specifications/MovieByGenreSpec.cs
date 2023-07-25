using Ardalis.Specification;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public class MovieByGenreSpec : Specification<Movie>
{
    public MovieByGenreSpec(string genre)
    {
        Query.Where(m => string.Equals(m.Genre, genre, StringComparison.OrdinalIgnoreCase));
    }
}