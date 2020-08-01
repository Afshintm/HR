using System;
using HR.Api.Domain.ValueObjects;

namespace HR.Api.Domain.Seed
{
    public interface IIntegrationEvent
    {
        Guid MessageId { get; }
        Guid CorrelationId { get; set; }
        ClientIdentity ClientIdentity { get; }
        Guid EntityId { get; }
        string EventType { get; }
        string RelativePath { get; }
    }
}