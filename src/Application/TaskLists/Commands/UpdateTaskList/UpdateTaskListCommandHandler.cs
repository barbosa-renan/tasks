using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.TaskLists.Commands.UpdateTaskList;

public record UpdateTaskListCommand : IRequest
{
    public Guid Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateTaskListCommandHandler : IRequestHandler<UpdateTaskListCommand>
{
    private readonly ITaskDbContext _context;

    public UpdateTaskListCommandHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TaskLists
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TaskList), request.Id);
        }

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}