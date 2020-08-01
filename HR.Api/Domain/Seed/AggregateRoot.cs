using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using HR.Api.Domain.Constants;
using HR.Api.Domain.ValueObjects;
using HR.Api.DomainEvents;
using HR.Api.Models;
using Microsoft.VisualBasic;

namespace  HR.Api.Domain.Seed
{
    public abstract class AggregateRoot: IEntity
    {
               protected AggregateRoot()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            CreationStatus = CreationStatus.InProgress;
            Messages = new Collection<EntityMessage>();
        }

        public ClientIdentity ClientIdentity { get; protected set; }
        public Collection<EntityMessage> Messages { get; protected set; }

        [IgnoreDataMember]
        public List<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

        [IgnoreDataMember]
        public List<IIntegrationEvent> IntegrationEvents { get; } = new List<IIntegrationEvent>();

        protected AggregateRoot(Guid id, DateTime dateCreated)
        {
            Id = id;
            DateCreated = dateCreated;
            Messages = new Collection<EntityMessage>();
            CreationStatus = CreationStatus.InProgress;
        }

        protected void Emit(IDomainEvent eventItem)
        {
            DomainEvents.Add(eventItem);
        }

        protected void Emit(IIntegrationEvent eventItem)
        {
            IntegrationEvents.Add(eventItem);
        }

        public virtual void Archive()
        {
            IsDeleted = true;
            DateDeleted = DateTime.UtcNow;
        }

       public CreationStatus CreationStatus { get; protected set; }

        public bool Locked { get; protected set; }

        public virtual void SetCreationStatus(CreationStatus status)
        {
            CreationStatus = status;
        }

        public virtual void Lock()
        {
            Locked = true;
        }

        public virtual void Unlock()
        {
            Locked = false;
        }

        public Guid Id { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime DateDeleted { get; protected set; }

        [IgnoreDataMember]
        public Guid EntityVersion { get; protected set; }
        public void SetEntityVersion(Guid version)
        {
            EntityVersion = version;
        }

    }
}