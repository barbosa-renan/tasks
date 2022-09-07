using Domain.Enums;

namespace Application.TaskLists.Queries.GetTasks;

public class TaskItemDTO 
{
    public Guid Id { get; set; }

    public Guid ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public Priority Priority { get; set; }

    public string? Note { get; set; }
}