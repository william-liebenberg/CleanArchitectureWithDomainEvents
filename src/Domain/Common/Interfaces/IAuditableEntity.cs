namespace CleanArchitectureWithDomainEvents.Domain.Common.Interfaces;

public interface IAuditableEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    public string? CreatedBy { get; set; } // TODO: String as userId? (https://github.com/SSWConsulting/CleanArchitectureWithDomainEvents/issues/76)
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; } // TODO: String as userId? (https://github.com/SSWConsulting/CleanArchitectureWithDomainEvents/issues/76)
}