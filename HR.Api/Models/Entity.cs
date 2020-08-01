using System;

namespace HR.Api.Models
{
    public interface IEntity
    {
        public Guid Id { get; }
        DateTime DateCreated { get; }
        bool IsDeleted { get; }
    }

    public abstract class Entity: IEntity
    {
        public DateTime DateCreated { get; }
        public bool IsDeleted { get; }
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = new Guid();
            DateCreated = DateTime.UtcNow;
            IsDeleted = false;
        }
    }
}