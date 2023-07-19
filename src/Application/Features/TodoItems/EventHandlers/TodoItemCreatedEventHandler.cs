﻿using Microsoft.Extensions.Logging;
using CleanArchitectureWithDomainEvents.Domain.Events;

namespace CleanArchitectureWithDomainEvents.Application.Features.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) => _logger = logger;

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("TodoItemCreatedEventHandler: {Title} was created", notification.Item.Title);

        return Task.CompletedTask;
    }
}