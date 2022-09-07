using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface ITaskDbContext
    {
        DbSet<TaskList> TaskLists { get; }

        DbSet<TaskItem> TaskItems { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
