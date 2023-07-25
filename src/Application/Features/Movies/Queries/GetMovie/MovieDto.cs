namespace CleanArchitectureWithDomainEvents.Application.Features.Movies;

public class MovieDto
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Rating { get; set; } = string.Empty;
    public TimeSpan Length { get; set; } = TimeSpan.FromMinutes(0);
}