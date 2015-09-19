using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Domain.Enum
{
    public enum AuthorizedGrantType : byte
    {
        AuthorizationCode = 1,
        RefreshToken = 2
    }
}
