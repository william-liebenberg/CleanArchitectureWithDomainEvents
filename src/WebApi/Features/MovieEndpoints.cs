using CleanArchitectureWithDomainEvents.Application.Features.Movies;
using CleanArchitectureWithDomainEvents.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureWithDomainEvents.WebApi.Features;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("movies")
            .WithTags("Movies")
            .WithOpenApi();

        group
            .MapGet("/", (ISender sender, CancellationToken ct) => sender.Send(new GetAllMoviesQuery(), ct))
            .WithName("GetAllMovies")
            .ProducesGet<MovieDto[]>();

        group
            .MapGet("/search/title", (ISender sender,
                [FromQuery] string title,
                CancellationToken ct) => sender.Send(new GetMovieByTitleQuery(title), ct))
            .WithName("GetMoviesByTitle")
            .ProducesGet<MovieDto[]>();

        group
            .MapGet("/search/genre", (ISender sender,
                [FromQuery] string genre,
                CancellationToken ct) => sender.Send(new GetMovieByGenreQuery(genre), ct))
            .WithName("GetMoviesByGenre")
            .ProducesGet<MovieDto[]>();

        group
            .MapGet("/search", (ISender sender,
                [FromQuery] string keyword,
                CancellationToken ct) => sender.Send(new GetMovieByKeywordSearchQuery(keyword), ct))
            .WithName("GetMoviesByKeywordSearch")
            .ProducesGet<MovieDto[]>();

        group
            .MapPost("/", (ISender sender, CreateMovieCommand command, CancellationToken ct) => sender.Send(command, ct))
            .WithName("CreateMovie")
            .ProducesPost();

        group
            .MapPut("/", (ISender sender, UpdateMovieCommand command, CancellationToken ct) => sender.Send(command, ct))
            .WithName("UpdateMovie")
            .ProducesPost();
    }
}