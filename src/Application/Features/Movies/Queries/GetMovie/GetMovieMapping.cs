using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public class GetMovieMapping : Profile
{
    public GetMovieMapping()
    {
        CreateMap<Movie, MovieDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id.Value))
            .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
            .ForMember(d => d.Genre, opt => opt.MapFrom(s => s.Genre))
            .ForMember(d => d.Rating, opt => opt.MapFrom(s => s.Rating))
            .ForMember(d => d.Length, opt => opt.MapFrom(s => s.Length));
    }
}
