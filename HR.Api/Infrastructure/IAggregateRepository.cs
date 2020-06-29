using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Api.Core;

namespace HR.Api.Infrastructure
{
    public interface IAggregateRepository<T> : IEntityRepository<T>
        where T : AggregateRoot
    {
        Task SaveAsync(IEnumerable<T> aggregate);
        Task<T> FindActiveByIdAsync(Guid aggregateId);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<bool> IsLocked(Guid aggregateId);
    }
}