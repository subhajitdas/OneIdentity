﻿using OneIdentity.Domain.Entity.Enum;
using System.Collections.Generic;

namespace OneIdentity.Domain.Entity
{
    public class Client
    {
        public Client()
        {
            AllowedScopes = new HashSet<Scope>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public OAuthFlow Flow { get; set; }
        public string RedirectUri { get; set; }
        public bool AllowRefreshToken { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual ICollection<Scope> AllowedScopes { get; set; }
    }
}