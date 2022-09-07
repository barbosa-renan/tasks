using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TaskLists.Commands.DeleteTaskList;

public record DeleteTaskListCommand(Guid Id) : IRequest;

public class DeleteTaskListCommandHandler : IRequestHandler<DeleteTaskListCommand>
{
    private readonly ITaskDbContext _context;

    public DeleteTaskListCommandHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TaskLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TaskList), request.Id);
        }

        _context.TaskLists.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}