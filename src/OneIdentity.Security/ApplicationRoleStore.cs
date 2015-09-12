using Microsoft.AspNet.Identity.EntityFramework;
using OneIdentity.Security.Entity;

namespace OneIdentity.Security
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole,string, ApplicationUserRole>
    {
        public ApplicationRoleStore(ApplicationIdentityDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
