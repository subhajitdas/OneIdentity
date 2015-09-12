using Microsoft.AspNet.Identity.EntityFramework;
using System;

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
