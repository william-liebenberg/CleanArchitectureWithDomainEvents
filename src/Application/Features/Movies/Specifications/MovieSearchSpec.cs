using Ardalis.Specification;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public class MovieSearchSpec : Specification<Movie>
{
    public MovieSearchSpec(string keyword)
    {
        Query.Where(m =>
            m.Title.Contains(keyword) ||
            m.Genre.Contains(keyword));
    }
}
