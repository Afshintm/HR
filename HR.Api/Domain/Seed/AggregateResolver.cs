using System;
using System.Linq;
using System.Threading.Tasks;
using HR.Api.Domain.Abstracts;
using HR.Api.Models;

namespace HR.Api.Domain.Seed
{
    public class AggregateResolver
    {
        private readonly IEntityRepository<Entity> _entityRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AggregateResolver(
            IEntityRepository<Entity> entityRepository,
            ITransactionRepository transactionRepository)
        {
            _entityRepository = entityRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<AggregateRoot> FindActiveByIdAsync(Guid aggregateId)
        {
            var entity = (await _entityRepository
                    .FindByPredicate(r =>
                        r.Id == aggregateId
                        && !r.IsDeleted))
                .FirstOrDefault();

            AggregateRoot specifiedAggregateRoot = null;
            if (entity != null)
            {
                specifiedAggregateRoot = await _transactionRepository.FindActiveByIdAsync<AggregateRoot>(entity.Id);
            }

            return specifiedAggregateRoot;

        }
    }
}