using System;
using System.Collections.Generic;
using HR.Api.Domain.Seed;

namespace HR.Api.Domain.ValueObjects
{
    public class UserIdentity: ValueObject
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public UserIdentity()
        {

        }

        public UserIdentity(Guid userId, string username)
        {
            UserId = userId;
            Username = username;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return UserId;
            yield return Username;
        }
    }
}