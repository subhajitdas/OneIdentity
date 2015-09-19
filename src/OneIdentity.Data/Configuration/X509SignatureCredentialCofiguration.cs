using OneIdentity.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Data.Configuration
{
    public class X509SignatureCredentialCofiguration: EntityTypeConfiguration<X509SignatureCredential>
    {
        public X509SignatureCredentialCofiguration()
        {
            this.Property(s => s.CertificateFindValue).HasMaxLength(255);
        }
    }
}
