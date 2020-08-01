using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Api.Core;
using HR.Api.Domain.Abstracts;
using HR.Api.Domain.Seed;

namespace HR.Api.Infrastructure
{
       public class AggregateRepository<T> : EntityRepository<T>, IAggregateRepository<T>
        where T : AggregateRoot
    {
        public AggregateRepository(IDocumentStore documentStore) : base(documentStore)
        {
        }

        // public async Task SaveAsync(IEnumerable<T> aggregates)
        // {
        //     //using var scope = DatabaseTracingScopeSpanCreator.StartForDatabaseSave(GetType(), typeof(T));
        //
        //     using (var session = DocumentStore.OpenSession())
        //     {
        //         foreach (var aggregate in aggregates)
        //         {
        //             session.Store(aggregate, aggregate.EntityVersion);
        //         }
        //
        //         await session.SaveChangesAsync();
        //
        //         foreach (var aggregate in aggregates)
        //         {
        //             aggregate.SetEntityVersion(session.VersionFor(aggregate).Value);
        //         }
        //     }
        // }
        //
        // public async Task<T> FindActiveByIdAsync(Guid aggregateId)
        // {
        //     using var scope = DatabaseTracingScopeSpanCreator.StartForDatabaseSelect(GetType(),typeof(T));
        //
        //     using (var session = DocumentStore.QuerySession())
        //     {
        //         var entity = await session.Query<T>()
        //             .FirstOrDefaultAsync(ag => ag.Id == aggregateId && !ag.IsDeleted);
        //
        //         SetEntityVersion(entity);
        //
        //         return entity;
        //     }
        // }
        //
        // public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        // {
        //     return FindByPredicates(new[]
        //     {
        //         predicate,
        //         ActiveRecordsExpression()
        //     });
        // }
        //
        // public new Task<T> FindFirst(Expression<Func<T, bool>> predicate)
        // {
        //     return FindFirstByPredicates(new[]
        //     {
        //         predicate,
        //         ActiveRecordsExpression()
        //     });
        // }
        //
        // public async Task<bool> IsLocked(Guid aggregateId)
        // {
        //     using var scope = DatabaseTracingScopeSpanCreator.StartForDatabaseSelect(GetType(),typeof(T));
        //
        //     using (var session = DocumentStore.QuerySession())
        //     {
        //         var result = await session.Query<T>()
        //             .Where(ag => ag.Id == aggregateId)
        //             .Select(r => r.Locked)
        //             .FirstOrDefaultAsync();
        //         return result;
        //     }
        // }
        //
        // private static Expression<Func<T, bool>> ActiveRecordsExpression()
        // {
        //     return item =>
        //         !item.IsDeleted &&
        //         item.CreationStatus != CreationStatus.Error;
        // }
        //

        public Task SaveAsync(IEnumerable<T> aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindActiveByIdAsync(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsLocked(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}