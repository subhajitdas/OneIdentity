using OneIdentity.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Data.Configuration
{
    public class SignatureCredentialConfiguration: EntityTypeConfiguration<SignatureCredential>
    {
        public SignatureCredentialConfiguration()
        {
            this.Property(s => s.Name).IsRequired().HasMaxLength(127);
            this.HasMany(s => s.Applications).WithRequired(a => a.SignatureCredential).HasForeignKey(a => a.SignatureCredentialId);
        }
    }
}
