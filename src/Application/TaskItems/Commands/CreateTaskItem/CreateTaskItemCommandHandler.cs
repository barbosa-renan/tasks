using Application.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.TaskItems.Commands.CreateTaskItem;

public record CreateTaskItemCommand : IRequest<Guid>
{
    public Guid TaskListId { get; init; }

    public string? Title { get; init; }
}

public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, Guid>
{
    private readonly ITaskDbContext _context;

    public CreateTaskItemCommandHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TaskItem
        {
            TaskListId = request.TaskListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TaskItemCreatedEvent(entity));

        _context.TaskItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}