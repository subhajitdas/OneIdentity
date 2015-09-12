using System.Collections.Generic;

namespace OneIdentity.Domain.Entity
{
    public class Application
    {
        public Application()
        {
            Clients = new HashSet<Client>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Audiance { get; set; }
        public int TokenLifetime { get; set; }
        public string AllowRefreshToken { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
