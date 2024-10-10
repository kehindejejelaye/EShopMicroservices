using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);

        //var context = eventData.Context;

        //if (context == null) return new ValueTask<InterceptionResult<int>>(result);

        //foreach (var entry in context.ChangeTracker.Entries())
        //{
        //    if (entry.Entity is IAuditableEntity auditableEntity)
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                auditableEntity.CreatedDate = DateTime.UtcNow;
        //                auditableEntity.CreatedBy = "system"; // Replace with actual user
        //                break;
        //            case EntityState.Modified:
        //                auditableEntity.LastModifiedDate = DateTime.UtcNow;
        //                auditableEntity.LastModifiedBy = "system"; // Replace with actual user
        //                break;
        //        }
        //    }
        //}

        //return new ValueTask<InterceptionResult<int>>(result);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.CreatedBy = "system";
            }

            if (entry.State == EntityState.Modified || entry.State == EntityState.Added || entry.HasChangedOwnedEntities())
            {
                entry.Entity.LastModified = DateTime.UtcNow;
                entry.Entity.LastModifiedBy = "system";
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
        r.TargetEntry != null &&
        r.TargetEntry.Metadata.IsOwned() &&
        (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    
}