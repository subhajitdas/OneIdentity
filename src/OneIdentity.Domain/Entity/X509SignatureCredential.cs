using System.Security.Cryptography.X509Certificates;

namespace OneIdentity.Domain.Entity
{
    public class X509SignatureCredential : SignatureCredential
    {
        public StoreLocation CertificateLocation { get; set; }
        public StoreName CertificateStore { get; set; }
        public X509FindType FindCertificateBy { get; set; }
        public string CertificateFindValue { get; set; }
    }
}

