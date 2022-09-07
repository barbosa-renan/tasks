using Application.TaskItems.Queries.GetTaskItems;
using Domain.Entities;

namespace Application.Mappers;

public class TaskItemMapper
{
    public static List<TaskItemPagedDTO> Map(List<TaskItem> taskItems)
    {
        return taskItems.ConvertAll(x => Map(x));
    }

    public static TaskItemPagedDTO Map(TaskItem item)
    {
        return new TaskItemPagedDTO
        {
            Done = item.Done,
            Id = item.Id,
            TaskListId = item.TaskListId,
            Title = item.Title
        };
    }
}