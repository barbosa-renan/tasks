using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.TaskItems.EventHandlers;

public class TaskItemCreatedEventHandler : INotificationHandler<TaskItemCreatedEvent>
{
    private readonly ILogger<TaskItemCreatedEventHandler> _logger;

    public TaskItemCreatedEventHandler(ILogger<TaskItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TaskItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
