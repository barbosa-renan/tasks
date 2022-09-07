using Application.Common.Mappings;
using Domain.Entities;

namespace Application.TaskLists.Queries.GetTasks;

public class TaskListDTO : IMapFrom<TaskList>
{
    public TaskListDTO()
    {
        Items = new List<TaskItemDTO>();
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Colour { get; set; }

    public IList<TaskItemDTO> Items { get; set; }
}