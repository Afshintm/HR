using System;
using System.Threading.Tasks;
using HR.Api.Domain.Abstracts;
using HR.Api.Domain.Seed;
using HR.Api.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HR.Api.Domain.Mediator
{
    public abstract class CommandHandler<TRequest, TResponse> : RequestHandler<TRequest, TResponse>
        where TRequest : BaseEntityRequest, IRequest<TResponse>
    {
         private readonly AggregateResolver _aggregateResolver;
          IEntity Entity { get; set; }

        protected CommandHandler(
            AggregateResolver aggregateResolver,
            ITransactionRepository transactionRepository,
            ILogger logger)
            : base(aggregateResolver, transactionRepository, logger)
        {
            _aggregateResolver = aggregateResolver;
        }

        protected override async Task ValidateEntity(Guid Id, TRequest request)
        {
            Entity = await _aggregateResolver.FindActiveByIdAsync(Id);

            if(Entity == null)  throw new ApplicationException($"EntityId {Id} not found.");

            ValidateClientIdentity(Entity, request);
        }

        protected void ValidateClientIdentity(IEntity entity, TRequest request)
        {
            if( request.ClientIdentity == null)
                throw new ApplicationException("Forbidden");
        }

        protected virtual bool ValidateLock(AggregateRoot aggregate)
        {
            return aggregate.Locked;
        }
    }
}