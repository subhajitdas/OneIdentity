using System.Collections.Generic;

namespace OneIdentity.Domain.Entity
{
    public class Scope
    {
        public Scope()
        {
            AllowedClients = new HashSet<Client>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ApplicationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual ICollection<Client> AllowedClients { get; set; }
    }
}