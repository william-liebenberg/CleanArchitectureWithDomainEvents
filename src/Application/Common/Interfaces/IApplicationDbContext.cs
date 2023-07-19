using Microsoft.EntityFrameworkCore;
using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}