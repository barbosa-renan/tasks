namespace Domain.Entities;

public class TaskItem : BaseEntity
{
    public Guid TaskListId { get; set; }
    public string? Title { get; set; }
    public string? Note { get; set; }
    public Priority Priority { get; set; }
    public DateTime? Reminder { get; set; }

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value == true && _done == false)
                AddDomainEvent(new TaskItemCompletedEvent(this));

            _done = value;
        }
    }

    public TaskList TaskList { get; set; } = null!;
}