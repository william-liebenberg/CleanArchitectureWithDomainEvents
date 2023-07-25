using Microsoft.EntityFrameworkCore;
using CleanArchitectureWithDomainEvents.Application.Common.Interfaces;
using CleanArchitectureWithDomainEvents.Domain.Entities;
using CleanArchitectureWithDomainEvents.Infrastructure.Persistence.Interceptors;
using System.Reflection;

namespace CleanArchitectureWithDomainEvents.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly EntitySaveChangesInterceptor _saveChangesInterceptor;
    private readonly PublishDomainEventsInterceptor _dispatchDomainEventsInterceptor;

    public ApplicationDbContext(
        DbContextOptions options,
        EntitySaveChangesInterceptor saveChangesInterceptor,
        PublishDomainEventsInterceptor dispatchDomainEventsInterceptor)
        : base(options)
    {
        _saveChangesInterceptor = saveChangesInterceptor;
        _dispatchDomainEventsInterceptor = dispatchDomainEventsInterceptor;
    }

    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Order of the interceptors is important
        optionsBuilder.AddInterceptors(_saveChangesInterceptor, _dispatchDomainEventsInterceptor);
    }
}