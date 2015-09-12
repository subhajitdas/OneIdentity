using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OneIdentity.Security.Entity
{
    public class ApplicationRole: IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
