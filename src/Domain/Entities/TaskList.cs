namespace Domain.Entities;

public class TaskList : BaseEntity
{
    public string? Title { get; set; }

    public Status Status { get; set; } = Status.Todo;

    public List<TaskItem> Items { get; private set; } = new List<TaskItem>();
}