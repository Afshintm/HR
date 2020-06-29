using System;
using System.Collections.Generic;
using HR.Api.DomainEvents;
using HR.Api.Models;

namespace HR.Api.Core
{
    public abstract class AggregateRoot: IEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; }
        public bool IsDeleted { get; }
        private List<DomainEvent> domainEvents { get; } = new List<DomainEvent>();

        protected AggregateRoot()
        {
            Id = new Guid();
            DateCreated = DateTime.UtcNow;
            IsDeleted = false;
        }

        protected void Emit(DomainEvent eventItem)
        {
            domainEvents.Add(eventItem);
        }

    }
}