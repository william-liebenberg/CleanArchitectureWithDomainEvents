using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using CleanArchitectureWithDomainEvents.Infrastructure.Persistence;
using CleanArchitectureWithDomainEvents.Infrastructure.Persistence.Interceptors;
using CleanArchitectureWithDomainEvents.Infrastructure.Services;

namespace CleanArchitectureWithDomainEvents.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<EntitySaveChangesInterceptor>();
        services.AddScoped<DispatchDomainEventsInterceptor>();

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"), builder =>
            {
                builder.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName);
                builder.EnableRetryOnFailure();
            }));

        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddSingleton<IDateTime, DateTimeService>();

        return services;
    }
}