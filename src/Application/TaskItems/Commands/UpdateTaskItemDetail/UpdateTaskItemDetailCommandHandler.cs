using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.TaskItems.Commands.UpdateTaskItemDetail;

public record UpdateTaskItemDetailCommand : IRequest
{
    public Guid Id { get; init; }

    public Guid ListId { get; init; }

    public Priority Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateTaskItemDetailCommandHandler : IRequestHandler<UpdateTaskItemDetailCommand>
{
    private readonly ITaskDbContext _context;

    public UpdateTaskItemDetailCommandHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTaskItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TaskItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TaskItem), request.Id);
        }

        entity.TaskListId = request.ListId;
        entity.Priority = request.Priority;
        entity.Note = request.Note;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
