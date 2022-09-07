namespace Application.TaskLists.Queries.GetTasks;

public class TasksVm
{
    public IList<PriorityDTO> Prioritys { get; set; } = new List<PriorityDTO>();

    public IList<TaskListDTO> Lists { get; set; } = new List<TaskListDTO>();
}