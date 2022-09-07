using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class TaskItemCompletedEvent : BaseEvent
{
    public TaskItem Item { get; }
    public TaskItemCompletedEvent(TaskItem item) => Item = item;
}
