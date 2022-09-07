using Application.TaskItems.Commands.CreateTaskItem;
using Application.TaskItems.Commands.DeleteTaskItem;
using Application.TaskItems.Commands.UpdateTaskItem;
using Application.TaskItems.Commands.UpdateTaskItemDetail;
using Application.TaskItems.Queries.GetTaskItems;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/task-items")]
public class TaskItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TaskItemPagedDTO>>> GetTaskItems([FromQuery] GetTaskItemsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateTaskItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateTaskItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(Guid id, UpdateTaskItemDetailCommand command)
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
        await Mediator.Send(new DeleteTaskItemCommand(id));

        return NoContent();
    }
}