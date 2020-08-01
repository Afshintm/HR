using System;
using System.Collections.Generic;
using HR.Api.Domain.Seed;

namespace HR.Api.Domain.ValueObjects
{
    public class EntityMessage : ValueObject
    {
        public EntityMessage(string message, string source = "")
        {
            Message = message;
            Source = source;
            DateCreated = DateTime.UtcNow;

        }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string Source { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Message;
            yield return DateCreated;
            yield return Source;
        }
    }
}