using CleanArchitectureWithDomainEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureWithDomainEvents.Infrastructure.Persistence.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    // TODO: Rip out the common pieces that are from BaseEntity (https://github.com/SSWConsulting/CleanArchitectureWithDomainEvents/issues/78)
    // virtual method, override 
    // Good marker to enforce that all entities have configuration defined via arch tests
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasConversion(x => x.Value, x => new MovieId(x))
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}