﻿using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using CleanArchitectureWithDomainEvents.Infrastructure.Persistence;
using CleanArchitectureWithDomainEvents.WebApi.Services;

namespace CleanArchitectureWithDomainEvents.WebApi;

public static class DependencyInjection
{
    public static void AddWebApi(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddOpenApiDocument(configure => configure.Title = "CleanArchitecture API");

        services.AddEndpointsApiExplorer();
    }
}