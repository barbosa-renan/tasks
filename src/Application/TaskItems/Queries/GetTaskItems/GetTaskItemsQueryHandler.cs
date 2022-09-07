using Application.Interfaces;
using Application.Mappers;
using MediatR;

namespace Application.TaskItems.Queries.GetTaskItems;

public record GetTaskItemsQuery : IRequest<List<TaskItemPagedDTO>>
{
    public Guid TaskListId { get; init; }
}

public class GetTaskItemsQueryHandler : IRequestHandler<GetTaskItemsQuery, List<TaskItemPagedDTO>>
{
    private readonly ITaskDbContext _context;

    public GetTaskItemsQueryHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItemPagedDTO>> Handle(GetTaskItemsQuery request, CancellationToken cancellationToken)
    {
        var taskItens = _context.TaskItems
            .Where(x => x.TaskListId == request.TaskListId)
            .OrderBy(x => x.Title);
       
        return TaskItemMapper.Map(taskItens.ToList());
    }
}
