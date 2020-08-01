using System;
using HR.Api.Domain.ValueObjects;

namespace HR.Api.Domain.Seed
{
    public class BaseEntityRequest
    {
        /// <summary>
        /// JSon Api impose limitation to have Id property
        /// </summary>
        public Guid Id { get; set; }
        public ClientIdentity ClientIdentity { get; set; }
        public string AuthToken { get; set; }
        public UserIdentity UserIdentity { get; set; }
        
    }
}