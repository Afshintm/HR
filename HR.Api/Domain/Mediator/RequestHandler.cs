using System;
using System.Threading;
using System.Threading.Tasks;
using HR.Api.Domain.Abstracts;
using HR.Api.Domain.Constants;
using HR.Api.Domain.Extensions;
using HR.Api.Domain.Seed;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace HR.Api.Domain.Mediator
{
    public abstract class RequestHandler<TRequest,TResponse>: IRequestHandler<TRequest,TResponse> 
        where TRequest : BaseEntityRequest, IRequest<TResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly AggregateResolver _aggregateResolver;
        private readonly ILogger _logger;

        public RequestHandler(AggregateResolver aggregateResolver,ITransactionRepository transactionRepository, ILogger logger)
        {
            _transactionRepository = transactionRepository;
            _aggregateResolver = aggregateResolver;
            _logger = logger;
        }

        public virtual async  Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateEntity(request.Id, request);
                _logger.Log(
                    LogLevel.Information,
                    $"{{@HandlerName}} {LoggerConstants.DefaultMessageTemplateWithBody}",
                    GetType().Name,
                    request?.Id,
                    request?.ClientIdentity?.TenantId,
                    request?.ClientIdentity?.ClientId,
                    _logger.ToSafeDataLog<TRequest>(request)
                );
                return await Execute(request, cancellationToken);

            }
            catch (Exception exception)
            {
                await OnErrorHandle(request, cancellationToken, exception);
                throw;;
            }
           
        }
        protected virtual async Task OnErrorHandle(TRequest request, CancellationToken cancellationToken, Exception exception)
        {
            //TODO: You can get the entity and save the messages with entity in db
            await Task.CompletedTask;
            
            _logger.LogError(exception,
                "HandlerName: @handlerName",
                GetType().Name,
                LoggerConstants.DefaultMessageTemplateWithBody,
                request?.Id,
                request?.ClientIdentity?.TenantId,
                request?.ClientIdentity?.ClientId,
                _logger.ToSafeDataLog<TRequest>(request));

        }

        protected abstract Task<TResponse> Execute(TRequest request, CancellationToken cancellationToken);
        protected abstract Task ValidateEntity(Guid Id, TRequest request);
    }
}