using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Api.Domain.Abstracts;
using HR.Api.Models;

namespace HR.Api.Infrastructure
{
    public class EntityRepository<T> : IEntityRepository<T>
        where T : IEntity
    {
        private IDocumentStore _documentStore;

        public EntityRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public Task<T> FindByIdAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindFirst(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindByPredicates(Expression<Func<T, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindFirstByPredicates(Expression<Func<T, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}