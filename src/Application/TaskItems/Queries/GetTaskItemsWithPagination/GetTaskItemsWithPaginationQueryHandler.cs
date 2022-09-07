using Application.Common.Mappings;
using Application.Common.Models;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.TaskItems.Queries.GetTaskItemsWithPagination;

public record GetTaskItemsWithPaginationQuery : IRequest<PagedList<TaskItemDTO>>
{
    public Guid TaskListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTaskItemsWithPaginationQueryHandler : IRequestHandler<GetTaskItemsWithPaginationQuery, PagedList<TaskItemDTO>>
{
    private readonly ITaskDbContext _context;
    private readonly IMapper _mapper;

    public GetTaskItemsWithPaginationQueryHandler(ITaskDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedList<TaskItemDTO>> Handle(GetTaskItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.TaskItems
            .Where(x => x.TaskListId == request.TaskListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TaskItemDTO>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
