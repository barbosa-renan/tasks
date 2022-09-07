namespace Application.TaskItems.Queries.GetTaskItems;

public class TaskItemPagedDTO 
{
    public Guid Id { get; set; }

    public Guid TaskListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}