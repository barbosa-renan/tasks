using Application.Interfaces;
using MediatR;

namespace Application.TaskLists.Commands.PurgeTaskLists;

public record PurgeTaskListsCommand : IRequest;

public class PurgeTaskListsCommandHandler : IRequestHandler<PurgeTaskListsCommand>
{
    private readonly ITaskDbContext _context;

    public PurgeTaskListsCommandHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PurgeTaskListsCommand request, CancellationToken cancellationToken)
    {
        _context.TaskLists.RemoveRange(_context.TaskLists);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}