using System;
using System.Threading;
using System.Threading.Tasks;
using HR.Api.Domain.Abstracts;
using HR.Api.Domain.Mediator;
using HR.Api.Domain.Seed;
using HR.Api.Queries;
using HR.Api.ViewModels;
using Microsoft.Extensions.Logging;

namespace HR.Api.Handlers
{
    public class GetEmployeeDetailsQueryHandler : QueryHandler<GetEmployeeDetailsQuery, AggregateRoot>
    {
        private AggregateResolver _aggregateResolver;
        public GetEmployeeDetailsQueryHandler(AggregateResolver aggregateResolver, TransactionRepository transactionRepository,ILogger<GetEmployeeDetailsQueryHandler> logger):base(aggregateResolver,transactionRepository,logger)
        {
            _aggregateResolver = aggregateResolver;
        }

        protected override async Task<AggregateRoot> Execute(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
             var employee = await _aggregateResolver.FindActiveByIdAsync(request.Id);
             return employee;

        }

        protected override Task ValidateEntity(Guid Id, GetEmployeeDetailsQuery request)
        {
            throw new NotImplementedException();
        }
    }
}