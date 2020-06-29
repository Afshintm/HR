using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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