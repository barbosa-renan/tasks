using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.TaskItems.Commands.UpdateTaskItem;

public record UpdateTaskItemCommand : IRequest
{
    public Guid Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateTaskItemCommandHandler : IRequestHandler<UpdateTaskItemCommand>
{
    private readonly ITaskDbContext _context;

    public UpdateTaskItemCommandHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TaskItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TaskItem), request.Id);
        }

        entity.Title = request.Title;
        entity.Done = request.Done;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
