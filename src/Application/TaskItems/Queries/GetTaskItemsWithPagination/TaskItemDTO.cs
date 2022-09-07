using Application.Common.Mappings;
using Domain.Entities;

namespace Application.TaskItems.Queries.GetTaskItemsWithPagination;

public class TaskItemDTO : IMapFrom<TaskItem>
{
    public Guid Id { get; set; }

    public Guid TaskListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}