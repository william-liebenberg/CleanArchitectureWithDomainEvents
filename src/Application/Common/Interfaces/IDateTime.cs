namespace CleanArchitectureWithDomainEvents.Application.Common.Interfaces;

public interface IDateTime
{
    // TODO: Talk to Gordon about this - System Clock (https://github.com/SSWConsulting/CleanArchitectureWithDomainEvents/issues/77)
    public DateTimeOffset Now => DateTimeOffset.UtcNow;
}