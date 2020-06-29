using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace HR.Api.Core
{
    public abstract class RequestHandler<TRequest,TResponse>: IRequestHandler<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        public virtual async  Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
           return await Execute(request, cancellationToken);
        }

        protected abstract Task<TResponse> Execute(TRequest request, CancellationToken cancellationToken);
    }
}