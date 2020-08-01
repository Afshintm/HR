using System;
using System.Threading;
using System.Threading.Tasks;
using HR.Api.Domain.Seed;
using MediatR;

namespace HR.Api.Core
{
    public abstract class EventHandlerBase<T>: INotificationHandler<T> where T: INotification
    {
        public Task Handle(T notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.ToString());
            return Task.CompletedTask;
        }
        protected abstract Task<AggregateRoot> Execute(T notification, CancellationToken cancellationToken);
    }
}