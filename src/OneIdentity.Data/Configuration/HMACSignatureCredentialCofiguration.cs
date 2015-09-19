using OneIdentity.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Data.Configuration
{
    public class HMACSignatureCredentialCofiguration: EntityTypeConfiguration<HMACSignatureCredential>
    {
        public HMACSignatureCredentialCofiguration()
        {
            this.Property(s => s.Key).HasMaxLength(512);
        }
    }
}
