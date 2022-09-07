using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence;

public class TaskDbContext : DbContext, ITaskDbContext
{
    private readonly IMediator _mediator;
    private readonly EntitySaveChangesInterceptor _entitySaveChangesInterceptor;

    public TaskDbContext(DbContextOptions<TaskDbContext> options,
                         IMediator mediator,
                         EntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
    {
        _mediator = mediator;
        _entitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<TaskList> TaskLists => Set<TaskList>();

    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_entitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}