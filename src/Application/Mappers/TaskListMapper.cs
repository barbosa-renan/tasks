using Application.TaskLists.Queries.GetTasks;
using Domain.Entities;

namespace Application.Mappers;

public class TaskListMapper
{
    public static List<TaskListDTO> Map(List<TaskList> TaskLists)
    {
        return TaskLists.ConvertAll(x => Map(x));
    }

    public static TaskListDTO Map(TaskList task)
    {
        return new TaskListDTO
        {
            Id = task.Id,
            Items = MapItems(task.Items),
            Status = task.Status,
            Title = task.Title
        };
    }

    private static IList<TaskItemDTO> MapItems(List<TaskItem> items)
    {
        return items.ConvertAll(x => MapItem(x));
    }

    private static TaskItemDTO MapItem(TaskItem x)
    {
        return new TaskItemDTO
        {
            Title = x.Title,
            Done = x.Done,
            Id = x.Id,
            ListId = x.TaskListId,
            Note = x.Note,
            Priority = x.Priority
        };
    }
}