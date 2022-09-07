using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.TaskLists.Commands.CreateTaskList;

public record CreateTaskListCommand : IRequest<Guid>
{
    public string? Title { get; init; }
}

public class CreateTaskListCommandHandler : IRequestHandler<CreateTaskListCommand, Guid>
{
    private readonly ITaskDbContext _context;

    public CreateTaskListCommandHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
    {
        var entity = new TaskList();

        entity.Title = request.Title;

        _context.TaskLists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}