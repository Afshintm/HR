using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Api.Domain.Seed;
using HR.Api.Models;

namespace HR.Api.Domain.Abstracts
{
    public interface ITransactionRepository
    {
        Task SaveAsync(params IEntity[] entities);
        Task SaveAsync(IEntity entity);
        Task<T> FindActiveByIdAsync<T>(Guid aggregateId) where T : AggregateRoot;
        Task<T> FindFirstByPredicate<T>(Expression<Func<T, bool>> expression) where T: AggregateRoot;
        Task<IEnumerable<T>> FindByPredicate<T>(Expression<Func<T, bool>> expression) where T : AggregateRoot;
    }

    public class TransactionRepository: ITransactionRepository
    {
        public Task SaveAsync(params IEntity[] entities)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveAsync(IEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> FindActiveByIdAsync<T>(Guid aggregateId) where T : AggregateRoot
        {
            throw new System.NotImplementedException();
        }

        public Task<T> FindFirstByPredicate<T>(Expression<Func<T, bool>> expression) where T : AggregateRoot
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> FindByPredicate<T>(Expression<Func<T, bool>> expression) where T : AggregateRoot
        {
            throw new System.NotImplementedException();
        }
    }
}