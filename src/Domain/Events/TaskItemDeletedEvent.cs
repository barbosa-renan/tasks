using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class TaskItemDeletedEvent : BaseEvent
{
    public TaskItem Item { get; }
    public TaskItemDeletedEvent(TaskItem item) => Item = item;
}
