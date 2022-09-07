using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TaskLists.Queries.GetTasks;

public record GetTasksQuery : IRequest<TasksVm>;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, TasksVm>
{
    private readonly ITaskDbContext _context;
    private readonly IMapper _mapper;

    public GetTasksQueryHandler(ITaskDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TasksVm> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        return new TasksVm
        {
            PriorityLevels = Enum.GetValues(typeof(Priority))
                .Cast<Priority>()
                .Select(p => new PriorityDTO { Value = (int)p, Name = p.ToString() })
                .ToList(),

            Lists = await _context.TaskLists
                .AsNoTracking()
                .ProjectTo<TaskListDTO>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
