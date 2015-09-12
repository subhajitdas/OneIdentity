using System.Collections.Generic;

namespace OneIdentity.Domain.Entity
{
    public class Scope
    {
        public Scope()
        {
            Clients = new HashSet<Client>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}