using System;
using System.Collections.Generic;
using HR.Api.Domain.Seed;

namespace HR.Api.Domain.ValueObjects
{
    public class ClientIdentity : ValueObject
    {
        public ClientIdentity()
        {
            TenantId = Guid.Empty;
            ClientId = Guid.Empty;
        }
        public ClientIdentity(Guid tenantId, Guid clientId)
        {
            TenantId = tenantId;
            ClientId = clientId;
        }

        public Guid TenantId { get; set; }

        public Guid ClientId { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TenantId;
            yield return ClientId;
        }
    }
}