using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Api.Core;
using HR.Api.Domain.Seed;

namespace HR.Api.Domain.Abstracts
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