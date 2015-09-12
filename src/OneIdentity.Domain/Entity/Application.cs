using System.Collections.Generic;

namespace OneIdentity.Domain.Entity
{
    public class Application
    {
        public Application()
        {
            Clients = new HashSet<Client>();
            Scopes = new HashSet<Scope>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Audiance { get; set; }
        public int TokenLifetime { get; set; }
        public bool AllowRefreshToken { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Scope> Scopes { get; set; }
    }
}
