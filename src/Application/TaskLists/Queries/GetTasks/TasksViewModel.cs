namespace Application.TaskLists.Queries.GetTasks;

public class TasksViewModel
{
    public IList<PriorityDTO> Priorities { get; set; } = new List<PriorityDTO>();

    public IList<TaskListDTO> Lists { get; set; } = new List<TaskListDTO>();
}