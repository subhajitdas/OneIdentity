using System.Collections.Generic;

namespace OneIdentity.Domain.Entity
{
    public abstract class SignatureCredential
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
