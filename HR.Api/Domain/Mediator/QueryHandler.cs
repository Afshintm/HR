using System;
using System.Threading.Tasks;
using HR.Api.Domain.Abstracts;
using HR.Api.Domain.Seed;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HR.Api.Domain.Mediator
{
    public abstract class QueryHandler<TRequest, TResponse> : RequestHandler<TRequest, TResponse>
        where TRequest : BaseEntityRequest, IRequest<TResponse>
    {
        private readonly AggregateResolver _aggregateResolver;
        protected AggregateRoot Entity { get; set; }

        protected QueryHandler(
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

            if (Entity == null) throw new ApplicationException($"Entity Id {Id.ToString()} was not found!");

            ValidateClientIdentity(Entity, request);
        }

        protected void ValidateClientIdentity(AggregateRoot aggregate, TRequest request)
        {
            if (request.ClientIdentity == null)
                throw new ApplicationException(
                    $"Aggregate root {aggregate.Id.ToString()} Tenant Id {request.ClientIdentity?.TenantId.ToString()} and Client Id {request.ClientIdentity?.ClientId.ToString()} do not match.");
        }

    }
}