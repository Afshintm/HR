using System;
using MediatR;

namespace HR.Api.DomainEvents
{
    public interface IDomainEvent: INotification
    {
        public Guid EventId { get; }
    }

    public abstract class DomainEvent : IDomainEvent
    {
        private readonly object _lockObject = new object();
        private Guid _eventId;
        public Guid EventId {
            get
            {
                if (_eventId == default)
                {
                    lock (_lockObject)
                    {
                        _eventId = new Guid();
                    }
                }
                return _eventId;
            }
        }
    }
}