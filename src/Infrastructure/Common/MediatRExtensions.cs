using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace MediatR;

public static class MediatRExtensions
{
    public static async Task DispatchDomainEvents(this IMediator mediatr, DbContext context)
    {
        var entities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediatr.Publish(domainEvent);
    }
}