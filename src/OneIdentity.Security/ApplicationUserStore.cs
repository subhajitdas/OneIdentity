using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using OneIdentity.Security.Entity;

namespace OneIdentity.Security
{
    public class ApplicationUserStore: UserStore<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(ApplicationIdentityDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
