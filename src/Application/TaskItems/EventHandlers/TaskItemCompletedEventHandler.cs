using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.TaskItems.EventHandlers;

public class TaskItemCompletedEventHandler : INotificationHandler<TaskItemCompletedEvent>
{
    private readonly ILogger<TaskItemCompletedEventHandler> _logger;

    public TaskItemCompletedEventHandler(ILogger<TaskItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TaskItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}