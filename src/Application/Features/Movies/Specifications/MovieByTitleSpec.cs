using Ardalis.Specification;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public class MovieByTitleSpec : Specification<Movie>
{
    public MovieByTitleSpec(string title)
    {
        Query.Where(m => m.Title == title);
    }
}
