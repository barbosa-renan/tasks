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

    /// <summary>
    /// Cria uma Task.
    /// </summary>
    /// <returns>Key da nova task criada.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/v1/task-lists
    ///     {
    ///         "title": "string"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Retorna o id da task criada recentemente</response>
    /// <response code="400">Se objeto da requisição não for válido</response>
    /// <response code="500">Se propriedades do objeto não passarem na validação</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> Create(CreateTaskListCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Atualiza as informações de uma Task List.
    /// </summary>
    /// <returns></returns>
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