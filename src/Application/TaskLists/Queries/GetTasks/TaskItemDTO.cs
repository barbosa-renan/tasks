using AutoMapper;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.TaskLists.Queries.GetTasks;

public class TaskItemDTO : IMapFrom<TaskItem>
{
    public Guid Id { get; set; }

    public Guid ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public int Priority { get; set; }

    public string? Note { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TaskItem, TaskItemDTO>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
    }
}