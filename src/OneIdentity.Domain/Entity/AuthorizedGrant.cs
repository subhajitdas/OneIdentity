using OneIdentity.Domain.Enum;
using System;
using System.Collections.Generic;

namespace OneIdentity.Domain.Entity
{
    public class AuthorizedGrant
    {
        public AuthorizedGrant()
        {
            Scopes = new HashSet<Scope>();
        }

        public string Id { get; set; }
        public string Subject { get; set; }
        public string ApplicationId { get; set; }
        public string ClientId { get; set; }
        public int RedirectUrlId { get; set; }
        public AuthorizedGrantType Type { get; set; }
        public DateTime IssuedOnUtc { get; set; }
        public DateTime ExpiresOnUtc { get; set; }
        public bool IsRevoked { get; set; }

        public virtual Application Application { get; set; }
        public virtual Client Client { get; set; }
        public virtual RedirectUrl RedirectUrl { get; set; }
        public virtual ICollection<Scope> Scopes { get; set; }
    }
}
