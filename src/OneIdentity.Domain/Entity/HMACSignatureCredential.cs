using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Domain.Entity
{
    public class HMACSignatureCredential:SignatureCredential
    {
        public byte[] Key { get; set; }
    }
}
