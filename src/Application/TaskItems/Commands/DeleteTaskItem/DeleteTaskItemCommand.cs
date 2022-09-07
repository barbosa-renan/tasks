using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.TaskItems.Commands.DeleteTaskItem;

public record DeleteTaskItemCommand(int Id) : IRequest;

public class DeleteTaskItemCommandHandler : IRequestHandler<DeleteTaskItemCommand>
{
    private readonly ITaskDbContext _context;

    public DeleteTaskItemCommandHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TaskItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TaskItem), request.Id);
        }

        _context.TaskItems.Remove(entity);

        entity.AddDomainEvent(new TaskItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
