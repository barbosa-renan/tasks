using Application.TaskLists.Commands.CreateTaskList;
using Application.TaskLists.Commands.DeleteTaskList;
using Application.TaskLists.Commands.UpdateTaskList;
using Application.TaskLists.Queries.GetTasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/task-lists")]
public class TaskListsController : ApiControllerBase
{
    /// <summary>
    /// Lista todas as Tasks.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<TasksViewModel>> Get()
    {
        return await Mediator.Send(new GetTasksQuery());
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateTaskListCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateTaskListCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteTaskListCommand(id));

        return NoContent();
    }
}