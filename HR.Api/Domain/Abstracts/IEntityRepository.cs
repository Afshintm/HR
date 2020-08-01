using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Api.Models;

namespace HR.Api.Domain.Abstracts
{
    public interface IEntityRepository<T>
        where T : IEntity
    {
        Task<T> FindByIdAsync(Guid entityId);
        Task<T> FindFirst(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByPredicates(Expression<Func<T, bool>>[] predicates);
        Task<T> FindFirstByPredicates(Expression<Func<T, bool>>[] predicates);
        Task SaveAsync(T entity);
        Task InsertAsync(T entity);
        Task InsertAsync(IEnumerable<T> entities);
        Task DeleteAsync(T aggregate);
        Task<bool> IsExists(Guid aggregateId);
    }
}