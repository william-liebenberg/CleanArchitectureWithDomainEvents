﻿namespace CleanArchitectureWithDomainEvents.Application.Common.Interfaces;

public interface ICurrentUserService
{
    public string? UserId { get; }
}