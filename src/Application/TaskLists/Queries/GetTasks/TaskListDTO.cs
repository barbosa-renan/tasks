using Domain.Enums;

namespace Application.TaskLists.Queries.GetTasks;

public class TaskListDTO
{
    public TaskListDTO()
    {
        Items = new List<TaskItemDTO>();
    }

    public Guid Id { get; set; }

    public string? Title { get; set; }

    public Status Status { get; set; }

    public IList<TaskItemDTO> Items { get; set; }
}