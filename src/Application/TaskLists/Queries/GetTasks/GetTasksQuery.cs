using Application.Interfaces;
using Application.Mappers;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TaskLists.Queries.GetTasks;

public record GetTasksQuery : IRequest<TasksViewModel>;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, TasksViewModel>
{
    private readonly ITaskDbContext _context;

    public GetTasksQueryHandler(ITaskDbContext context)
    {
        _context = context;
    }

    public async Task<TasksViewModel> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var priorities = Enum.GetValues(typeof(Priority))
                .Cast<Priority>()
                .Select(p => new PriorityDTO { Value = (int)p, Name = p.ToString() })
                .ToList();

        var lists = await _context.TaskLists.Include(x=>x.Items)
                .AsNoTracking()
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken);

        return new TasksViewModel
        {
            Priorities = priorities,
            Lists = TaskListMapper.Map(lists)
        };
    }
}
