using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class TaskItemCreatedEvent : BaseEvent
{
    public TaskItem Item { get; }
    public TaskItemCreatedEvent(TaskItem item) => Item = item;
}
